    Repository GetRepository<T>()
    {
      //need to call T.IsQueryable, but can't!!!
      //need to call T.RowCount
      //need to call T.DoSomeStaticMath(int param)
    }
    
    ...
    var r = GetRepository<Customer>()
