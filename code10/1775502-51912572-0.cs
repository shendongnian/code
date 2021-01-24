    DataTable table = new DataTable();
        table.Columns.Add("Date");
        for(int i=18;i<21;i++)
        {
            table.Rows.Add("8/"+i+"/2018 13:38:00");
        }
        TxtDateReceived.Text = table.Rows[2][0].ToString();
