    public void SomeMethod(bool include, Func<int, bool> query)
    {
        using (AccountDataContext db = AccountContextFactory.CreateContext())
        {
             var query = from a in db.FundingTypes where query(a.FundingTypeId) select a;
        }
    }
