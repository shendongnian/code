    //Presenter method called after initial load from database
    private void CheckDataBaseForWrongTypes(string table)
    {
        foreach (DataGridViewColumn col in _table.Columns)
        {
            col.ValueType = typeof(string);
        }
        DataTable typeCheckerDT = _model.GetSchemaForCurrentTable(table);
        int i = -1;
        foreach (DataRow row in typeCheckerDT.Rows)
        {
            i++;
            string col = Convert.ToString(row.ItemArray[1]);
            string type = Convert.ToString(row.ItemArray[2]);
            if (type.Equals("TEXT") || type.Equals("BLOB")) //Columns of this type will always display correctly, as far as I know
            {
                continue;
            }
            //Correct values in numeric field that are actually stored as strings in database
            DataTable invalidTable = _model.GetNonNumericDataInSpecifiedColumn(table, col);
            DataTable dt = _model.GetMainTableDT();
            dt.PrimaryKey = new DataColumn[] { dt.Columns["rowid"] };
            foreach (DataRow invalidRow in invalidTable.Rows)
            {
                int rowPrimaryKey = Convert.ToInt32(invalidRow.ItemArray[0]);
                DataRow rowToModifyType = dt.Rows.Find(rowPrimaryKey);
                int index = dt.Rows.IndexOf(rowToModifyType);
                _table.Rows[index].Cells[i + 1].Value = _model.GetActualDataBaseStringValueInANumericColumn(_table.Name, rowPrimaryKey, col);
            }
            if (type.Equals("REAL") || type.Equals("NUMERIC")) //Decimals will only be displayed incorrectly in integer columns
            {
                continue;
            }
            //Correct values in integer field that are actually decimals
            invalidTable = _model.GetDecimalDataInSpecifiedColumn(table, col);
            dt = _model.GetMainTableDT();
            dt.PrimaryKey = new DataColumn[] { dt.Columns["rowid"] };
            foreach (DataRow invalidRow in invalidTable.Rows)
            {
                int rowPrimaryKey = Convert.ToInt32(invalidRow.ItemArray[0]);
                DataRow rowToModifyType = dt.Rows.Find(rowPrimaryKey);
                int index = dt.Rows.IndexOf(rowToModifyType);
                _table.Rows[index].Cells[i + 1].Value = _model.GetActualDataBaseRealValueInAnIntegerColumn(_table.Name, rowPrimaryKey, col);
            }
        }
    }
