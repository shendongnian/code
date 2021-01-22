    Units.UnitsDataTable dataTable = new Units.UnitsDataTable();
    foreach (Units.UnitsRow row in dataTable.Rows)
    {
        if (row.IsPrimaryKeyNull())
            //....
        if (row.IsForeignKeyNull())
            //....
    }
