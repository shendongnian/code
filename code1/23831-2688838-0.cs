    Dim myView As DataView = dr.GetSchemaTable().DefaultView
    myView.RowFilter = "ColumnName = 'ColumnToBeChecked'"
    If myView.Count > 0 AndAlso dr.GetOrdinal("ColumnToBeChecked") <> -1 Then
      obj.ColumnToBeChecked = ColumnFromDb(dr, "ColumnToBeChecked")
    End If
