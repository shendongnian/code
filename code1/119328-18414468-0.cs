    Private Sub FavoritesBar_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles FavoritesBar.SelectedIndexChanged
        FavIndex = FavoritesBar.SelectedIndex 'FavIndex is declared as a public string.
        Dim Loc As Point = New Point(MousePosition)
        FavMenu.Location = Loc
        FavMenu.ShowDialog()
    End Sub
