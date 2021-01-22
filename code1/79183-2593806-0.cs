    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {   
        // Get the BackgroundWorker that raised this event.
        BackgroundWorker worker = sender as BackgroundWorker;
        using(SQLiteConnection cnn = new SQLiteConnection("Data Source=MyDatabase.db"))
        {
            cnn.Open();
            int TotalQuerySize = GetQueryCount("Query", cnn); // This needs to be implemented and is not shown in example
            using (SQLiteCommand cmd = cnn.CreateCommand())
            {
                cmd.CommandText = "Query is here";
                using(SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    int i = 0;
                    while(reader.Read())
                    {
                        // Access the database data using the reader[].  Each .Read() provides the next Row
                        if(worker.WorkerReportsProgress) worker.ReportProgress(++i * 100/ TotalQuerySize);
                    }
                }
            }
        }
    }
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        this.progressBar1.Value = e.ProgressPercentage;
    }
       
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // Notify someone that the database access is finished.  Do stuff to clean up if needed
        // This could be a good time to hide, clear or do somthign to the progress bar
    }
    
    public void AcessMySQLiteDatabase()
    {
        BackgroundWorker backgroundWorker1 = new BackgroundWorker();
        backgroundWorker1.DoWork += 
            new DoWorkEventHandler(backgroundWorker1_DoWork);
        backgroundWorker1.RunWorkerCompleted += 
            new RunWorkerCompletedEventHandler(
        backgroundWorker1_RunWorkerCompleted);
        backgroundWorker1.ProgressChanged += 
            new ProgressChangedEventHandler(
        backgroundWorker1_ProgressChanged);
    }
