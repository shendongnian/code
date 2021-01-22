    Private Sub ContextItem_Clicker(Byval sender As Object, Byval e As EventArgs)
        Dim temp As ContextMenuItem = TryCast(sender, ContextMenuItem)
        If temp IsNot Nothing Then
            If temp.Name = "whatever" Then
            End If
        End If
    End Sub
