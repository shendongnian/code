       MySqlDataAdapter sda = new MySqlDataAdapter();
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0 && dt != null)
            {
                gvr_rkit.DataSource = dt;
                gvr_rkit.DataBind();
            }
