    const string devMachine = @"Data Source=C:\_DEVELOPMENT\__.NET\dotNetSnippets\Mine\TestSqlite\test.s3db";
    
    SQLiteConnection c = new SQLiteConnection(devMachine);
    SQLiteDataAdapter da = new SQLiteDataAdapter();
    DataTable dt = new DataTable();
    
    public Form1()
    {
        InitializeComponent();
    
       
        da = new SQLiteDataAdapter("select product_id, product_name, abbrev from product", c);
    
        var b = new SQLiteCommandBuilder(da);
    
        da.InsertCommand = b.GetInsertCommand();
        da.UpdateCommand = b.GetUpdateCommand();
        da.DeleteCommand = b.GetDeleteCommand();
    		
        da.Fill(dt);
    
    
        da.RowUpdated += da_RowUpdated;
        
    
        bds.DataSource = dt;
        grd.DataSource = bds;
    
    
    
    }
    
    void da_RowUpdated(object sender, System.Data.Common.RowUpdatedEventArgs e)
    {
        if (e.StatementType == StatementType.Insert)
        {
    	    int ident = (int)(long) new SQLiteCommand("select last_insert_rowid()", c).ExecuteScalar();
    	    e.Row["product_id"] = ident;
        }
    }
    
    private void uxUpdate_Click(object sender, EventArgs e)
    {
        da.Update(dt);
    }
