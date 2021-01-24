     using(SqlConnection con = new SqlConnection("connectionString"))
    {
        con.Open();
		using(SqlDataAdapter da = new DataAdapter("SELECT HotSheetID, Today, Part, Timeord, Timerec, sdock, LCCN, Requestor, Notes, Type, Shift, RunOutTime, CICSTYPE FROM ILC,Reasontype WHERE Reasontype.typeID = ILC.typeID AND ILC.Today BETWEEN COALESCE(@date1, ILC.Today) AND COALESCE(@date2, ILC.Today)")
		{
			da.SelectCommand.Parameters.AddWithValue("@date1", dt3.Text); //Like this we pass parameters to query. In case of dates it will transform your date to correct format.
			da.SelectCommand.Parameters.AddWithValue("@date2", dt4.Text); //Like this we pass parameters to query. In case of dates it will transform your date to correct format.
			
			DataTable dt = new DataTable();
			da.Fill(dt);
			
			//rest of the code
		}
    }
