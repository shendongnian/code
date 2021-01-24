    string customerUniqueID = "test";
    
    string constr = ConfigurationManager.ConnectionStrings["SQLConnection"].ToString(); // connection string
    SqlConnection con = new SqlConnection(constr);
    con.Open();
    SqlCommand com = new SqlCommand("SELECT * FROM [Customers] WHERE [UniqueID] = @UniqueID", con); // table name 
    com.Parameters.Add("@UniqueID", SqlDbType.Int);
    com.Parameters["@UniqueID"].Value = customerUniqueID;
    SqlDataAdapter da = new SqlDataAdapter(com);
    DataSet ds = new DataSet();
    da.Fill(ds, "Customers");
    
    companyName.Text = ds.Tables[0].Rows[0]["CompanyName"].ToString();
