Public Class frmGeneric
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearScreenControls(Me)
    End Sub

    Private Sub frmGeneric_Load(sender As Object, e As EventArgs) Handles Me.Load
        cboLetterGrade.Items.Add("A")
        cboLetterGrade.Items.Add("B")
        cboLetterGrade.Items.Add("C")
        cboLetterGrade.Items.Add("D")
        cboLetterGrade.Items.Add("F")
    End Sub

    Private Sub txtName_GotFocus(sender As Object, e As EventArgs) Handles txtName.GotFocus, txtGrade.GotFocus, txtAge.GotFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.SelectAll()


    End Sub
    Private Sub txtName_LostFocus(sender As Object, e As EventArgs) Handles txtName.LostFocus, txtGrade.LostFocus, txtAge.LostFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.DeselectAll()


    End Sub

    Private Sub btnAction_Click(sender As Object, e As EventArgs) Handles btnAction.Click
        Dim blnErrors As Boolean
        Dim cntrl As Control
        Dim intPosition As Integer

        If Not ValidateTextBoxLength(txtName, errP) Then
            blnErrors = True

        End If
        If Not ValidateTextBoxNumeric(txtAge, errP) Then
            blnErrors = True

        End If

        If Not ValidateCombo(cboLetterGrade, errP) Then
            blnErrors = True
        End If
        If blnErrors Then

        End If
        For Each cntrl In Me.Controls
            If TypeOf cntrl Is GroupBox Then
                UpperCaseText(cntrl)
            End If
        Next
        intPosition = cboLetterGrade.FindStringExact(txtGrade.Text)
        If intPosition <> -1 Then
            cboLetterGrade.SelectedIndex = intPosition
        Else
            MessageBox.Show("Could not find this grade in the combo")
        End If

    End Sub

    Private Sub UpperCaseText(grpBox As GroupBox)
        For Each cntrl In grpBox.Controls
            If TypeOf cntrl Is TextBox Then
                Dim tBox As TextBox = DirectCast(cntrl, TextBox)
                tBox.Text = tBox.Text.ToUpper
            End If
        Next

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()

    End Sub
End Class
