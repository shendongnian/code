    private async Task GetSomeData(string sSQL)
    {
        DataSet results = await FilldataAsync(ProcName, TableName);
        //Populate once data received
        grdRes.DataSource = results.Tables[0];
    }
