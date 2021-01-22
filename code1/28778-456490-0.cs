           using (ITransaction transaction = _session.BeginTransaction())
           {
               _session.Save(calc);
               _session.Flush();
               transaction.Commit();
           }
       }
