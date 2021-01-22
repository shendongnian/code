    public static void Select(DataGridView dataGridView,
                              DataSetContainer dataSetContainer, 
                              params object[] parameters)
    {
        AsyncCommandExecutor commandExecutor = new AsyncCommandExecutor(System.Threading.SynchronizationContext.Current);
        commandExecutor.ExecuteWithContinuation(
        () =>
        {
            // this is the long-running bit
            dataSetContainer.DataSet = getDataFromDb(parameters);
            // This is the continuation that will be run on the UI thread
           return () =>
           {
               dataGridView.DataSource = _dataSet.Tables[0].DefaultView;
           };
        });
        
    }
