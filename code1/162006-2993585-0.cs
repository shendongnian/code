       public void Commit(Enlistment enlistment)
       {
          Transaction currentTx = Transaction.Current;
          if (currentTx != null)
          {
             currentTx.RollBack(new Exception("I give up!");
          }
       }
