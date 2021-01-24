        DataTable chart_DateTable = new DataTable();
        chart_DateTable = Selected_DataTables.Copy();
        foreach (DataRow row in chart_DateTable.Rows)
        {
            
            DateTime test2 = DateTime.Parse(row["Datum"].ToString());
            row["Datum"] = test2.Date;
        }
