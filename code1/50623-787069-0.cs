    // Inside each using TransactionScope(), hhok up the current transaction completed event
    Transaction.Current.TransactionCompleted += new TransactionCompletedEventHandler(Current_TransactionCompleted);
    // handle the event somewhere else
    void Current_TransactionCompleted(object sender, TransactionEventArgs e)
    {
      //  check the status of the transaction
      if(e.Transaction.TransactionInformation.Status == TransactionStatus.Aborted)
        // do something here
    }
