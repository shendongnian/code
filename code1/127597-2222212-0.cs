    public enum PayPalTransactionType
    {
        Authorization(0, Debit),
        Capture(1, Credit),
        Refund(3, null),
        Void(4. null);
    
        private final int code;
    
        public int getCode()
        {return(code);}
    
        private PayPalTransactionType(final int code, final TransactionType transactionType)
        {
           this.code = code;
           this.transactionType = transactionType;
        }
        private TransactionType getTransactionType()
        {return(transactionType);}
    }
    
