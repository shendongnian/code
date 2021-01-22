    protected void BindMarketCodes()
    {
        using(var dc = new LINQOmniDataContext())
        {
            dd2.DataSource = from p in db.lkpMarketCodes
                             orderby 0
                             select new {p.marketName, p.marketCodeID };
            dd2.DataTextField = "marketName";
            dd2.DataValueField = "marketCodeID";
            dd2.DataBind();
        }
    }
    
    // no need to use ToList()
    // no need to use a temp list;
    // using an anonymous type will limit the columns in your resulting SQL select
    // make sure to wrap in a using block;
