    void Init()
    {
        ValidateOrder += SomeValidateMethod;
        CommitOrder += SomeCommitMethod;
        RejectOrder += SomeRejectMethod;
    }
    void OrderReceived(Order o)
    {
      OrderEventArgs OEA = new OrderEventArgs(o);
   
      ValidateOrder(this, OEA);
      if (OEA.OrderIsValid)
          CommitOrder(this, OEA);
      else
          RejectOrder(this, OEA);
    }
