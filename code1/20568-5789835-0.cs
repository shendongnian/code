    Dim t As Table = TryCast(grid.Controls(0), Table)
    If t IsNot Nothing Then
        t.Rows.AddAt(0, row)
    End If
    t.EnableViewState = false;
