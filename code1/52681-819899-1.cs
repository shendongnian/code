     public bool validateAmount(string amount)
     {
         int decimalPlaces = amount.Length - amount.IndexOf(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator) - 1;
         if (decimalPlaces > 2)
         {
             //handle error with args, or however your validation works
             return false;
         }
         decimal decAmount;
         if (decimal.TryParse(amount, out decAmount))
         {
             if (decAmount >= 0)
             {
                 //positive
             }
             else
             {
                 //negative
             }
         }
         return true;
     }
