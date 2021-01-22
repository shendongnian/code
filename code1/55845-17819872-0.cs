       try
       {
          //make here the changes
          m_DB.SubmitChanges();
          tran.Complete();
       }
       catch (Exception ex)
       {
           Transaction.Current.Rollback();
       }
    }
