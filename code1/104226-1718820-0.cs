    // In your ASPX page
    DataTable dt = new DataTable()
    ... // populate the table from the database
    
    userControl1.Source = dt;
    userControl2.Source = dt;
    ...
    userControl7.Source = dt;
    
    // In your user controls
    // Assumes a GridView called myGridView
    public DataTable Source
    {
        set
        {
            myGridView.DataSource = value;  //or hold it somewhere else
        }
    }
