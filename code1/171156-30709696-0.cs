    Private Sub ProductsGrid_MouseDown(sender As Object, e As MouseEventArgs) Handles ProductsGrid.MouseDown
        Dim grid = DirectCast(sender, DataGridView)
        If grid.HitTest(e.X, e.Y).Type = DataGridViewHitTestType.RowHeader Then
            grid.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            grid.EndEdit()
        ElseIf grid.EditMode <> DataGridViewEditMode.EditOnEnter Then
            grid.EditMode = DataGridViewEditMode.EditOnEnter
        End If
    End Sub
