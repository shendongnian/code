    public void fetchEmployeeDetail()
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                try
                {
                    adp = new SqlDataAdapter("select * from Emp where number =" + Request.QueryString["id"], con);
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        name.Text = dt.rows[0]["name"].ToString(); // name means your table column name 
                        address.Text = dt.rows[0]["name"].ToString();
                        birth.Text = dt.rows[0]["name"].ToString();
                    }
                }
                catch
                {
    
                }
            }
