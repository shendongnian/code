    using(var ts = new TransactionScope)
    {
          using(var db = new TransactionScope)
          {
             //do db processing
          }
          using(var msmq = new TransactionScope)
          {
             //do msmq processing
          }
          ts.Complete();
    }
