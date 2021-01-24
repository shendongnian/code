    string customerUniqueID = "test";
    string constr = ConfigurationManager.ConnectionStrings["SQLConnection"].ToString(); // connection string
    using(SqlConnection con = new SqlConnection(constr))
    {
        SqlCommand com = con.CreateCommand();
        com.CommandText = "SELECT * FROM [Customers] WHERE [UniqueID] = @UniqueID";
        com.Parameters.Add("@UniqueID", SqlDbType.Int);
        com.Parameters["@UniqueID"].Value = customerUniqueID;
        using(SqlDataAdapter da = new SqlDataAdapter(com))
        {
            DataTable dt = new DataTable();
            da.Fill(dt);
            companyName.Text = dt.Rows[0].Field<string>("CompanyName");
        }
    }
