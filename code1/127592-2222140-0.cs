    public enum PayPalTransactionType
    {
      Authorization = 0, // Debit 
      Capture = 1, // Credit 
      Refund = 2,
      Void = 3,
      Max  // This must always be the last type and is used just as a marker.
    }
    string[] ActionCode = new string[(int)PayPalTransactionType.Max] { "Debit", "Credit", "Refund", "Void" };
    public string GetPayPalTransCode(PayPalTransactionType payPalTransactionType)
    {
      return ActionCode[(int)payPalTransactionType];
    } 
