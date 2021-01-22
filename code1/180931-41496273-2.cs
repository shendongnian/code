     public void ImplicitTest()
        {
            Price aPrice = 1.23m;
            Decimal aDecimal = 3.4m;
            Weight aWeight = 132.0m;
            // ok implicit cast
            aPrice = aDecimal;
            aDecimal = aPrice;
            // ok implicit cast
            aWeight = aDecimal;
            aDecimal = aWeight;
            // Errors 
            aPrice = aWeight;
            aWeight = aPrice;
            
            NeedsPrice(aPrice);   //ok
            NeedsDecimal(aPrice); //ok
            NeedsWeight(aPrice);  //error
            NeedsPrice(aDecimal);   //ok
            NeedsDecimal(aDecimal); //ok
            NeedsWeight(aDecimal);  //ok
            NeedsPrice(aWeight);   //error
            NeedsDecimal(aWeight); //ok
            NeedsWeight(aWeight);  //ok
        }    
    
