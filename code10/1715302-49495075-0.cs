    lock (sync)
    {
        DataRow newRow = dataTable.NewRow();
        contractRow["column1"] = item.Value1;
        contractRow["column2"] = item.Value2;
        dataTable.Rows.Add(newRow);
    }
