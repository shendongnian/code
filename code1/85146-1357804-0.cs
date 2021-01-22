    GridView1.DataSource = getQuery(ConnectionString, "select * from mytable");
    GridView1.DataBind();
     private DataTable getQuery(string ConnStr, string query)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr)) //@"Data Source=MMI31_14;Initial Catalog=PowerHouse;Connect Timeout=30;UID=sa;pwd=dtdbAdmin"))
                using (SqlDataAdapter cmd = new SqlDataAdapter(query, conn))
                    cmd.Fill(dt);
            }
            catch { }
            return dt;
        }
