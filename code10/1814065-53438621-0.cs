      public void LoadTasksTable()
    {
        try
        {
            int i = 0;
            int index = 0;
            for(var i = 0; i < tasksDT.Rows.Length; i++)
            {
                dataTasks.Rows[i].Cells["TASK #"].Value = i;
                dataTasks.Rows[i].Cells["PLATFORM"].Value = dataTasks.Rows[i].Cells["PLATFORM"].Value;
                dataTasks.Rows[i].Cells["TASK TYPE"].Value = dataTasks.Rows[i].Cells["TASK TYPE"].Value;
                dataTasks.Rows[i].Cells["KEYWORD"].Value = dataTasks.Rows[i].Cells["KEYWORD"].Value;
                dataTasks.Rows[i].Cells["LINK"].Value = dataTasks.Rows[i].Cells["LINK"].Value;
                dataTasks.Rows[i].Cells["PROFILE"].Value = dataTasks.Rows[i].Cells["PROFILE"].Value;
            
            }
            connection.Close();
        }
        catch { }
    }
