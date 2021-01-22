    class Runner
    {
      Transaction StartTransaction()
      {
        return new Transaction(this);
      }
    }
    
    class Transaction
    {
      Transaction Run()
      Transaction StopTransaction()
    }
