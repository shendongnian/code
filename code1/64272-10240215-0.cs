    TaskScheduler uiScheduler = GetUISheduller();
    SqlCommand command1 = CreateCommand1();
    Task<SqlDataReader> query1 = Task<SqlDataReader>.Factory.FromAsync(command1.BeginExecuteReader, command1.EndExecuteReader, null);
    query1.ContinueWith(t => PopulateGrid1(t.Result), uiScheduler);
    SqlCommand command2 = CreateCommand2();
    query1.ContinueWith(t => Task<SqlDataReader>.Factory.FromAsync(command2.BeginExecuteReader, command2.EndExecuteReader, null)
          .ContinueWith(t => PopulateGrid2(t.Result), uiScheduler);
