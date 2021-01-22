    object oTotal = CompTab.Compute("Sum(share)", "IsRep=0");
    Decimal total;
    if(!oTotal == null)
    {
       if(!System.Decimal.TryParse(oTotal.ToString(), out total))
       {
            // whatever logic you need to include if the TryParse fails.
            // Should never happen in this case.
       }
    }
