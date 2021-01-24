    public PXAction<Customer> customerHistory;
    [PXUIField(DisplayName = AR.Messages.CustomerHistory, MapEnableRights = PXCacheRights.Select, MapViewRights = PXCacheRights.Select)]
    [PXButton(ImageKey = PX.Web.UI.Sprite.Main.Report)]
    public virtual IEnumerable CustomerHistory(PXAdapter adapter)
    {
    	Customer customer = this.BAccountAccessor.Current;
    	if (customer != null && customer.BAccountID > 0L)
    	{
    		Dictionary<string, string> parameters = new Dictionary<string, string>();
    		parameters["CustomerID"] = customer.AcctCD;
    		throw new PXReportRequiredException(parameters, "AR652000", AR.Messages.CustomerHistory);
    	}
    	return adapter.Get();
    }
