    using (SqlConnection con = new SqlConnection(conString))
    using (SqlCommand cmd = new SqlCommand("GetLedger", con))
    using (SqlDataAdapter sda = new SqlDataAdapter())
    {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SQLParameter("@optb", Data.SqlDbType.VarChar);
            cmd.Parameters.Add(new SQLParameter("@startsession", Data.SqlDbType.DateTime));
           
            cmd.Parameters.Add(new SQLParameter("@endsession", Data.SqlDbType.DateTime));
            command.Parameters("@optb").Value = p1;
            command.Parameters("@startsession").Value = pp2;
            command.Parameters("@startsession").Value = pp3;
            sda.SelectCommand = cmd;
            using (ledgerdt ds = new ledgerdt())
            {
                sda.Fill(ds, "ledgerdt");
                return ds;
            }
    }
