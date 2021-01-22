    int priceSum,totDiscount;
    
    if(int.TryParse(dsfDataSet.itemTotals.Compute( "SUM(priceSum)", String.Empty ).ToString(),out priceSum))
    {
      if(int.TryParse(dsfDataSet.discountItems.Compute("SUM(totDiscount)", String.Empty).ToString(),out totDiscount))
      {
        priceSum - totDiscount;
      }
    }
