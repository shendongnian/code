    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
           regionDropDown();
        }
    }
    DataSet mySet; // ?
    public void regionDropDown() {
    
        // Define ADO.NET objects.
        string connectionString = WebConfigurationManager.ConnectionStrings["northwindConString"].ConnectionString;
        SqlConnection myConn = new SqlConnection(connectionString);
            myConn.Open();
            SqlCommand cmd = new SqlCommand("Select * FROM Region", myConn);
            SqlDataAdapter daRegion = new SqlDataAdapter(cmd);
            DataSet dsRegion = new DataSet();
            daRegion.Fill(dsRegion, "Region");
            mySet = dsRegion;
            
            // If you want,custom logic then you might use this code,
           // else just provide datatextfield and datavalue field before binding..
            foreach (DataRow row in dsRegion.Tables["Region"].Rows)
            {
                ListItem ls = new ListItem();
                ls.Text = row["RegionID"].ToString();
                ls.Value = row["RegionID"].ToString();
                regionDropDownList.Items.Add(ls);
    
            }
        myConn.Close();
    }
