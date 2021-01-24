    private List<SmoothiePrices> prices = new List<SmoothiePrices>();
    public void InitSmoothies
    {
       prices.Add(new SmoothiePrices() 
       {
         Name = "Regular",
         SizeAndPrice = new Dictionary<string, double>() 
         {
            {"Small", 5.99},
            {"Normal", 6.99}
            // And so on
         };
       });
    }
