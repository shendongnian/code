    using (MyDataContext dc = _conn.GetContext())
    {
        var options = new DataLoadOptions();
        options.LoadWith<Account>(a => a.Email);
        options.LoadWith<Account>(a => a.Profile);
        options.LoadWith<Account>(a => a.HostInfo);
        dc.LoadOptions = options;
        try
        {
            account = (from a in dc.Accounts
                       where a.UserName == userName
                       select a).FirstOrDefault();
        }
        catch
        {
            //oops
        }
    }
