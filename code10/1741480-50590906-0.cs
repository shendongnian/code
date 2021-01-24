    public void Dispose()
    {
       _database.Dispose();
       GC.Collect();
       GC.WaitForPendingFinalizers();
    }
