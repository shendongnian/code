    public DataTable sqlToDTCompare(string conStr, string stpName, DateTime startDate, DateTime endDate, int percent)
        {
            //receives connection string and stored procedure name
            //then returns populated data table
            DataTable dt = new DataTable();
            using (var con = new SqlConnection(conStr))
            using (var cmd = new SqlCommand(stpName, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = endDate;
                cmd.Parameters.Add("@Percent", SqlDbType.Int).Value = percent;
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            return dt;
        }
