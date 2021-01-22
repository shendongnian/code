    protected void Page_Load(object sender, EventArgs e)
    {
        // If we're in postback, let's not poll the database.
        if (Page.IsPostback)
            return; // Change this if you do need some postback processing here.
        // I assume that in the real world you pull this info from web.config
        string Server = "al2222";
        string Username = "hshshshsh";
        string Password = "sjjssjs";
        string Database = "database1";
        string ConnectionString = "Data Source=" + Server + ";";
        ConnectionString += "User ID=" + Username + ";";
        ConnectionString += "Password=" + Password + ";";
        ConnectionString += "Initial Catalog=" + Database;
        string query = "Select * from Customer_Order where orderNumber = 17";
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                // Going to assume that you're only getting 1 record 
                // due to apparent key (orderNumber = 17) in query?
                // You can also consider "if (dr.Read())", but fundamentally
                // they will do the same thing.
                while (dr.Read())
                {
                    Interests.DataSource = dr;
                    Interests.DataTextField = "OptionName";
                    Interests.DataValueField = "OptionName";
                    Interests.DataBind();
                }
                // I've excised the calls to .Close() and .Dispose(),
                // as the using block covers them for you.
            }
        }
    }
