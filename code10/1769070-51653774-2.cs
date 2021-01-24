    private void updateTasksDGV(DateTime? start, DateTime? end)
    {
        if (!end.HasValue)
        {
          end = DateTime.MaxValue;
        }
    	if (!start.HasValue)
    	{
    		string query = "select * from CRS_Diary where cast(EndDate as date) <= convert(date,GETDATE()) and Complete = 0";
    		dgvTasks.DataSource = GetTable(query);
    		return;
    	}
    
    	try
    	{
    		DataTable tbl = new DataTable();
    		using (SqlConnection connection = getSQlCon())
    
    		{
    
    			using (SqlCommand cmd = new SqlCommand(@"Select * from crs_diary 
    			where enddate >= @Start and endDate < @End and complete = 0", connection))
    			{
    				MessageBox.Show("made it to conn " + start.ToString() + "  -  " + end.ToString());
    
    				cmd.Parameters.Add(new SqlParameter("@Start", SqlDbType.DateTime));
    				cmd.Parameters.Add(new SqlParameter("@Start", SqlDbType.DateTime));
    
    				cmd.Parameters["@Start"].Value = start;
    				cmd.Parameters["@End"].Value = end;
    
    				connection.Open();
    				tbl.Load(cmd.ExecuteReader());
    
    				System.Windows.Forms.Clipboard.SetText(cmd.CommandText.ToString());
    			}
    		}
            dgvTasks.DataSource = null;
            dgvTasks.DataSource = tbl;
    	}
    	catch (System.Data.DataException ex)
    	{
    		MessageBox.Show(ex.Message);
    
    	}
    }
