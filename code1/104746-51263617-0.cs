    string strOrderId="435242A";
    
    bool isDecimal = isDecimal(value);
    
    
    public bool isDecimal(string value)
    {
    
    try
    {
      Decimal.Parse(value);
      return true;
    }
    catch
    {
      return false;
    }
    }
