     using (DataSet ds = new DataSet())
        {
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);
            string str = "User ID=username;Password=password;Data Source=Test";
            OracleConnection conn = new OracleConnection(str);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from table_name";
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd); 
            da.Fill(dt);
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
