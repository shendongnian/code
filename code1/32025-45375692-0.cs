    foreach (DataRow dataRow in myDataTable.Rows)
    {
        Trace.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        foreach (DataColumn dataCol in myDataTable.Columns)
        {
            object v = dataRow[dataCol];
            Type t = dataCol.DataType;
            bool e = false;
            if (t.IsEnum) e = true;
            Trace.WriteLine((dataCol.ColumnName + ":").PadRight(30) +
                (e ? Enum.ToObject(t, v) : v));
        }
    }
