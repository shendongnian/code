            GridColumn fCol = gridView1.Columns.Add();
            RepositoryItemCheckEdit fCheckEdit = new RepositoryItemCheckEdit();
            fCheckEdit.ValueChecked = "YES";
            fCheckEdit.ValueUnchecked = "NONO";
            fCol.ColumnEdit = fCheckEdit;
            fCol.FieldName = "Haganise";
