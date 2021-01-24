    foreach (string CIInfo in CiInformation)
    {
        var localTable = new DataTable();
        string[] CIId = CIInfo.Split(',');
        string query1 = "Some Query"
        if (conn.State == ConnectionState.Open)
        {
            SqlCommand cmd = new SqlCommand(query1, conn);
            cmd.CommandTimeout = 50000;
            localTable .Load(cmd.ExecuteReader());
        }
        string CSV = DataTableToCSV(localTable, ',');
        File.WriteAllText("D:\\NonMsCSV\\" + CIId[0] + ".csv", CSV);
    }
