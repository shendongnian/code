    protected void Page_Load(object sender, EventArgs e)
    {    
        string connectionString = 
             ConfigurationManager.ConnectionStrings["SEV2"].ConnectionString;
        string commandText = "YOUR QUERY";
    
        using (var con = new SqlConnection(connectionString))
        using (var command = new SqlCommand(commandText, con))
        {
            con.Open();
            lblTotalApplicants.Text = command.ExecuteScalar().ToString();
        }
    }
