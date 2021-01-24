    Money myMoneyField = (Money)EntityObject.GetAttributeValue<Money>(Amount);
    decimal actualAmount;
    
    if (myMoneyField != null)
    {
        actualAmount = myMoneyField.Value;
    }
