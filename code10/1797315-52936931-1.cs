    private void Find_Button_Click(object sender, EventArgs e)
    {
        FindEmails();
    }
    public void FindEmails()
    {
        DataTable dt = new DataTable();
        //Add columns to DataTable
        
        //Do stuff to get "searchFolders" and "searchCriteria" from form
        //...
        //Create OutlookFunctions instance
        OutlookFunctions oFunctions = new OutlookFunctions();
        oFunctions.RunAdvancedSearch(searchFolders, searchCriteria);
    }
    public void DataGridFiller(DataTable results)
    {
        EmailList.DataSource = results;
    }
