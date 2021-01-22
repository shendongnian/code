    Private Sub ProductsGrid_MouseDown(sender As Object, e As MouseEventArgs) Handles ProductsGrid.MouseDown
        Dim grid = DirectCast(sender, DataGridView)
        Dim info = grid.HitTest(e.X, e.Y)
        If into.Type = DataGridViewHitTestType.RowHeader OrElse info.Type = DataGridViewHitTestType.TopLeftHeader Then
            grid.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            grid.EndEdit()
        ElseIf grid.EditMode <> DataGridViewEditMode.EditOnEnter Then
            grid.EditMode = DataGridViewEditMode.EditOnEnter
        End If
    End Sub
