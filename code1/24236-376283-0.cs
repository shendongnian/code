    DataTable dtHistoricalPricing = null;
...
    if (!Page.IsPostBack)
    {
       if (dtHistoricalPosting == null)
       {
           //shouldn't need to do a new dtHistoricalPricing as the method below is returning a new instance?
           dtHistoricalPricing = historicalPricing.GetAuctionData();
       }
    }
