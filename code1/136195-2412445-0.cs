    public static void UpdateAmounts( this IEnumerable< IAmount > amounts, decimal totalAmount )
    {
      foreach ( IAmount amount in amounts ) 
      {
         var myType = amount.GetType();
         var myTypeProperties = myType.GetProperties();
         foreach (PropertyInfo h_pi in myTypeProperties) 
         {
            if (h_pi.Property_Type == typeof(decimal)) // or h_pi.Name == "Amount" || h_pi.Name                                      == "GrossAmount"...
            {
               //DoStuff
            }
         }
      }
        amount.Amount = GetAmount();      
    }
