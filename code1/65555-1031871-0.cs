        grd.DataSource = DT
        'set autosize mode
        grd.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        grd.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        grd.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'datagrid has calculated it's widths so we can store them
        For i = 0 To grd.Columns.Count - 1
            'store autosized widths
            Dim colw As Integer = grd.Columns(i).Width
            'remove autosizing
            grd.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            'set width to calculated by autosize
            grd.Columns(i).Width = colw
        Next
