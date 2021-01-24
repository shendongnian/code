    public enum SendLogicType {
        Change,
        Purchase
    }
    public static SendLogicSelector {
        public static ISendLogic GetSendLogic(SendLogicType type) 
        {
             switch(type)
             {
                 case SendLogicType.Change:
                      return new ChangeSendLogic();
                 case SendLogicType.Purchase:
                      return new PurchaseSendLogic();
             }
        }
    }
