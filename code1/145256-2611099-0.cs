    if (string.IsNullOrEmpty(mvi))
    {
       money.Currency = 0M;
    }
    else 
    {
       decimal temp = 0M;
       if (decimal.TryParse(mvi, out temp))
       {
            money.Currency = temp;
       }
       else 
       {
           // you have an invalid input, handle
       }
    }
