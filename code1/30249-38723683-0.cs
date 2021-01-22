      public void SaveChanges()
      {
          _session.Flush();
          _session.Transaction.Commit();
          _session.BeginTransaction();
      }
