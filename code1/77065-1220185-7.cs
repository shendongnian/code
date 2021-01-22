    Public Sub SomeMethod()
        Dim updateForm As Action(Of String()) = New Action(Of String())(AddressOf Me.OnAction)
        Me.form.Invoke(updateForm, New Object() { e })
    End Sub
    Private Sub OnAction(ByVal arguments As String())
        form.WindowState = FormWindowState.Normal
        form.OpenFiles(arguments)
    End Sub
