    using (SqlConnection con = new SqlConnection(strConn))
    {
        con.Open();
        using (SqlCommand cmd = new SqlCommand("getStationInfo", con))
        {
            using (SqlDataAdapter ada = new SqlDataAdapter(cmd))
            {
                using (DataTable dtStationsReturned = new DataTable())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.CommandText = "dbo.getStationInfo";
                    SqlParameter sp = new SqlParameter("@stationList", dtStationCodes);
                    sp.SqlDbType = SqlDbType.Structured;
                    sp.UdtTypeName = "dbo.udtableStationCode";
                    cmd.Parameters.Add(sp);
                    ada.Fill(dtStationsReturned);
                }
            }
        }
    }
