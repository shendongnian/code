    public string GetPayPalTransCode
        (PayPalServiceBase.PayPalTransactionType payPalTransactionType)
    {
        string actionCode = string.Empty;
    
        switch (payPalTransactionType)
        {
            case PayPalServiceBase.PayPalTransactionType.Authorization:
                actionCode = "Debit";
                break;
            case PayPalServiceBase.PayPalTransactionType.Capture:
                actionCode = "Credit";
                break;
        }
    
        return actionCode;
    }
