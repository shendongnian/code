        DataRow[] rows = _dsmenu.Tables["tblmenu"].Select("id='" + DocID + "'");
        rows[0]["Allow"] = "Yes";
        DataTable table = new DataTable();
        foreach (DataRow row in rows)
        {
            table.ImportRow(row);
        }
        table.WriteXml(""); // Take this into database.
