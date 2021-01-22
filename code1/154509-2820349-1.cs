    public Form1()
    {
    	InitializeComponent();
    
    
    	var c = Connect();
    
    	var da = new SqlDataAdapter("select emp_id, emp_firstname, emp_lastname from emp where 1 = 0", c);
    
    
    
    	var b = new SqlCommandBuilder(da);
    
    	var getIdentity = new SqlCommand("SELECT CAST(@@IDENTITY AS INT)", c);
    
    	da.InsertCommand = b.GetInsertCommand();
    	da.UpdateCommand = b.GetUpdateCommand();
    	da.DeleteCommand = b.GetDeleteCommand();
    	da.RowUpdated += (xsender, xe) =>
    	{
    		if (xe.Status == UpdateStatus.Continue && xe.StatementType == StatementType.Insert)
    		{
    			xe.Row["emp_id"] = (int)getIdentity.ExecuteScalar();
    		}
    	};
    
    
    	var dt = new DataTable();
    	da.Fill(dt);
    
    	var nr = dt.NewRow();
    	nr["emp_firstname"] = "john";
    	nr["emp_lastname"] = "lennon";
    
    
    	var nrx = dt.NewRow();
    	nrx["emp_firstname"] = "paul";
    	nrx["emp_lastname"] = "mccartney";
    
    
    	dt.Rows.Add(nr);
    	dt.Rows.Add(nrx);
    
    	da.Update(dt);
    
    	dt.AcceptChanges();
    
    
    	nrx["emp_lastname"] = "simon";
    	da.Update(dt);
    
    	nr["emp_lastname"] = "valjean";
    	da.Update(dt);
    
    }
    
    
    
    SqlConnection Connect()
    {
    	return new SqlConnection(@"data source=.\SQLEXPRESS;Database=Test;uid=sa;pwd=hey");
    }
