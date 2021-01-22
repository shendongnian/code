        public void NeedsPrice(Price aPrice)
        {
        }
        public void NeedsWeight(Weight aWeight)
        {
        }
        public void NeedsDecimal(Decimal aDecimal)
        {
        }
      public void ExplicitTest()
        {
            Price aPrice = (Price)1.23m;
            Decimal aDecimal = 3.4m;
            Weight aWeight = (Weight)132.0m;
            // ok
            aPrice = (Price)aDecimal;
            aDecimal = (Decimal)aPrice;
            // Errors need explicit case
            aPrice = aDecimal;
            aDecimal = aPrice;
            //ok
            aWeight = (Weight)aDecimal;
            aDecimal = (Decimal) aWeight;
            // Errors need explicit cast
            aWeight = aDecimal;
            aDecimal = aWeight;
            // Errors (no such conversion exists)
            aPrice = (Price)aWeight;
            aWeight = (Weight)aPrice;
            // Ok, but why would you ever do this.
            aPrice = (Price)(Decimal)aWeight;
            aWeight = (Weight)(Decimal)aPrice;
            NeedsPrice(aPrice);   //ok
            NeedsDecimal(aPrice); //error
            NeedsWeight(aPrice);  //error
            NeedsPrice(aDecimal);   //error
            NeedsDecimal(aDecimal); //ok
            NeedsWeight(aDecimal);  //error
            NeedsPrice(aWeight);   //error
            NeedsDecimal(aWeight); //error
            NeedsWeight(aWeight);  //ok
        }
