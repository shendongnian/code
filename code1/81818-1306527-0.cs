    Private Shared messageNumber as Integer
    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case messageNumber
            Case 0
                lblMessage.Text = MESSAGE_1
            Case 1
                lblMessage.Text = MESSAGE_2
            Case 2
                lblMessage.Text = MESSAGE_3
            Case 3
                lblMessage.Text = MESSAGE_4
        End Select
        messageNumber = (messageNumber + 1) Mod 4
    End Sub
