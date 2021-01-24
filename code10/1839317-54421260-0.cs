    public void DoWork()
    {
      TransactionOptions tranOptions = UtilityBL.GetTransOptions();
      using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, tranOptions))
      {
        try {
          DAL.InsertDetails1();
          DAL.InsertDetails2();
          scope.Complete();
        }
        catch (Exception ex)
        {
            log.Info(string.Format(UploadMessages.FailedMsg));
            if (ContextUtil.IsInTransaction)
              ContextUtil.SetAbort();
        }
      }
    }
