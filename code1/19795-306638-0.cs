    public void BindData(string mySQL)
    {
      OracleConnection myConnection;
      // Empty connection string for now
      OracleDataAdapter MainDataAdapter = new OracleDataAdapter(mySQL, ""); 
      DataTable MainDataTable = new DataTable();
      string connectionString = "";
      Label1.Visible = false;
      Label1.Text = "";
    
      foreach (ListItem li in CheckBoxList1.Items)
      {
        if (li.Selected)
        {
          connectionString = "Data Source=" + li.Text + "";
          connectionString += ";Persist Security Info=True;User ID=user;Password=pass;Unicode=True";
          MainDataAdapter.SelectCommand.ConnectionString = connectionString
          try
          {
            MainDataAdapter.Fill(MainDataTable);
          }
          catch (OracleException e)
          {
            Label1.Visible = true;
            Label1.Text = Label1.Text + e.Message + " on " + li.Text + "<br>";
          }
        }
      }
      GridView1.DataSourceID = String.Empty;
      GridView1.DataSource = MainDataTable;
      GridView1.DataBind();
    }
