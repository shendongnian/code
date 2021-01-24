    for (int i = 0; i < gridView1.DataRowCount; i++) {
        object b = gridView1.GetRowCellValue(i, "FieldName");
        if (b != null && b.Equals(<someValue>)){
            gridView1.FocusedRowHandle = i;
            return;
        }
    }
