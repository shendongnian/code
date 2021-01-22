    public void ExecuteP()
    {
      QueryBD facade = new QueryBD.
      foreach (DataRow dr in dtResults.Rows)
      {
        int Local_number = Convert.toInt32(dr["autonum"].ToString());
        new Thread(new ParameterizedThreadStart(facade.QueryCounter)).Start(Local_number);
      }
    }
    public void QueryCounter(object _counter)
    {
      ...
    }
