    context.BeginTransaction(); // another one of my library functions
    try {
      var b = new Batch { ... };
      b.Insert(); // save the batch record immediately
      while (addNewItems) {
        ...
        var i = new BatchItem { ... };
        b.BatchItems.Add(i);
        i.Insert(); // send the SQL on each iteration
      }
      context.CommitTransaction(); // and only commit the transaction when everything is done.
    } catch {
      context.RollbackTransaction();
      throw;
    }
