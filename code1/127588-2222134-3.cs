    public string GetPayPalTransCode(PayPalServiceBase.PayPalTransactionType payPalTransactionType)
    {
        // ...
        switch (payPalTransactionType)
        {
            case PayPalServiceBase.PayPalTransactionType.Authorization:
                break;
            case PayPalServiceBase.PayPalTransactionType.Capture:
                break;
        }
        // ...
    }
