ManualResetEvent[] waitEvents = 
  Array.ConvertAll<DataRow, ManualResetEvent>(
      StoredProcedureParameters.Tables[0].Rows.OfType&lt;DataRow>().ToArray(),
      (row) =>
      {
          ManualResetEvent mre = new ManualResetEvent(false);
          ThreadPool.QueueUserWorkItem(
              WorkerFunction, 
              new WorkerClass()
              {
                  Event = mre,
                  Parameters = row.Table.Columns.OfType&lt;DataColumn>()
                      .ToDictionary(
                          column => column.ColumnName, 
                          column => (object)null)
              });
          return mre;
      });
