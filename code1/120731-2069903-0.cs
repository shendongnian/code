    public DateTime EntryTime
    {
      get  { return ((ITransaction)this).EntryTime; }
    }
    
    DateTime ITransaction.EntryTime
    {
      get { throw new NotImplementedException(); }
    }
