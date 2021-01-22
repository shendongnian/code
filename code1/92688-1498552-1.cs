    Private Sub ContextItem_Clicker(Byval sender As Object, Byval e As EventArgs)
        Dim castedItem As ContextMenuItem = TryCast(sender, ContextMenuItem)
        If castedItem IsNot Nothing Then
            If castedItem.Name = "whatever" Then
                ' Do something remotely useful here
            End If
        End If
    End Sub
