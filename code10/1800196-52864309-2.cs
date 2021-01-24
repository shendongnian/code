    if (string.IsNullOrEmpty(creditCard.CardNumber))
    {
          ModelState.AddModelError("PaymentAmount", "Credit card number is required.");
    }
    
    if (string.IsNullOrEmpty(creditCard.ExpirationDateMonth) || string.IsNullOrEmpty(creditCard.ExpirationDateYear))
    {        
        ModelState.AddModelError("PaymentAmount", "Expiration date is required.");
    }
    
    if (string.IsNullOrEmpty(creditCard.NameOnCard))
    {
        ModelState.AddModelError("PaymentAmount", "Name is required.");
    }
    
    […]
