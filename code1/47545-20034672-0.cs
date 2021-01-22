    AutoCompleteStringCollection acs = new AutoCompleteStringCollection();
    acs.Clear();
    
    try
    {
        this.Cursor = Cursors.WaitCursor;
        OleDbCommand odc = new OleDbCommand("<your sql statement>", <your connection>);
        OleDbDataReader odr = odc.ExecuteReader();
    
        while (odr.Read())
        {
    	    acs.Add(odr["name"].ToString());
        }
    
        textbox1.AutoCompleteCustomSource = acs;
    }
    catch (Exception ex)
    {
        throw new ex;
    }
    finally
    {
        this.Cursor = Cursors.Default;
    }
