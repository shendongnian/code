    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        try
        {
            e.Result = GetTableData();
        }
        catch (Exception ex)
        {
            e.Result = ex;
        }
    }
    
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        // only display progress, do not assign it to grid
    }
    
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Result is DataTable)
        {
           dataGridView1.DataSource = e.Result as DataTable;
        }
        else if (e.Result is Exception)
        {
        }
    }
    
    private DataTable GetTableData()
    {
        DataTable table = new DataTable();
        for (int i = 0; i < NumOfRows; i++)
        {
            //... fill data here
            backgroundWorker1.ReportProgress(i * 100F / NumOfRows);
        }
        return table;
    }
