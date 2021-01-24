    public void ExecQuery(Func<IEnumerable<testtable>, float?> filter)
    {
       var results = from a in tests
       group a by a.TransactionDate.Month into j
       select new
       {
          Month = j.Key,
          Total = filter(j)//actually this the little update needed here
       };
    }
