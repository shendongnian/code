    Private LVUsersLastHit As Point
        Private Sub lvUsers_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvUsers.MouseUp
            Me.LVUsersLastHit = e.Location
        End Sub
        Private Sub LvUsers_Doubleclick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvUsers.DoubleClick
            Dim HTI As ListViewHitTestInfo = Me.lvUsers.HitTest(Me.LVUsersLastHit)
            If HTI.Item Is Nothing OrElse HTI.SubItem Is Nothing Then Exit Sub 'nothing was dblclicked
            MsgBox("doubleClicked the " & HTI.Item.ToString & " Item  on the " & HTI.SubItem.ToString & " sub Item")
        End Sub
