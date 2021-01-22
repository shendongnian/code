        Dim a As DataView
        Dim b As DataView
        a.Table.Merge(b.Table)
        Dim c As New DataView
        c.Table.Merge(a.Table)
