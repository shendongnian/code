    for (int i = 0; i < colFields.Length; ++i)
    {
		string column = colFields[i];
        DataColumn datecolumn = new DataColumn(column);
        datecolumn.AllowDBNull = true;
        if (column == "Column001")
        {
        }
    }
