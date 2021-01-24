    static public DataTable get_I1(RunningTests rt)
    {
    	DataTable dt = new DataTable();
    
    	using (SqlConnection cs = new SqlConnection(connString))
    	{
    		//string query = string.Format("Select TOP {0} Serial AS [Serial #], Start, [Stop], N, ROUND(Mean,4) AS Mean, ROUND(StdDev,4) AS [Standard Deviation], ROUND(Minimum,4) AS Min, ROUND(Maximum,4) AS Max FROM TestTime JOIN Membrane ON TestTime.Membrane_ID = Membrane.Membrane_ID WHERE Serial LIKE '{1}' ORDER BY TestTime_ID", numRecords, serial);
    		string query = string.Format("SELECT Time_Stamp, I1 FROM Test WHERE Unit_ID = '{0}' AND Time_Stamp >= '{1}' AND Time_Stamp <= '{2}'", rt.Unit_ID, rt.StartTime.Ticks, rt.StopTime.Ticks);
    		SqlCommand cmd = new SqlCommand(query, cs);
    
    		using (SqlDataAdapter da = new SqlDataAdapter(cmd))
    		{
    			da.Fill(dt);
    		}
    	}
    
    	//Previous user stored the date time as ticks, have to convert back to DateTime
    	DataTable dtCloned = new DataTable();
    	dtCloned.Clear();
    	dtCloned.Columns.Add("Time_Stamp", typeof(DateTime));
    	dtCloned.Columns.Add("I1", typeof(int));
    
    	foreach (DataRow dr in dt.Rows)
    	{
    		DataRow r = dtCloned.NewRow();
    		r[0] = new DateTime((long)dr[0]);
    		r[1] = dr[1];
    
    		dtCloned.Rows.Add(r);
    	}
    
    	dtCloned.DefaultView.Sort = "Time_Stamp DESC";
    	dtCloned = dtCloned.DefaultView.ToTable();
    
    	return dtCloned;
    }
