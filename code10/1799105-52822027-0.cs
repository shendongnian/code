    DateTime start, end;
    if (DateTime.TryParse(txtStart.Text, out start) && DateTime.TryParse(txtEnd.Text, out end))
    {
      string cmd = @"SELECT Name,Present 
          from AttendanceRecords   
          where [Date] between @start and @end";
    
      SqlDataAdapter da = new SqlDataAdapter(cmd, con);
      da.SelectCommand.Parameters.Add("@start", SqlDbType.DateTime).Value = start;
      da.SelectCommand.Parameters.Add("@end", SqlDbType.DateTime).Value = end;
    
      DataTable dt = new DataTable();
      da.Fill(dt);
      GridView2.DataSource = dt;
      GridView2.DataBind();
    }
    else
    {
        lbldatercrd.Text = "NOT FOUND";
    }
