    decimal dOne = -966.96M; 
    decimal dTwo = 2300M;  
    try
    {
      decimal dResult = Decimal.Round((dOne / dTwo), 28, MidpointRounding.AwayFromZero); 
    }
    catch (OverflowException)
    {
      Console.WriteLine(dOne);
      Console.WriteLine(dTwo);
    }
