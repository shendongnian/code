    protected void BindMarketCodes()
    {    
        using (var dataContext = new LINQOmniDataContext()) {
            //bind to Country COde droplist
            dd2.DataSource = from p in dataContext.lkpMarketCodes 
                orderby p.marketName
                select new {p.marketCodeID, p.marketName};
            dd2.DataTextField = "marketName";
            dd2.DataValueField = "marketCodeID";
            dd2.DataBind();
        }
    }
    
