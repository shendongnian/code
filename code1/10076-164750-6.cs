    public void SomeProprietarySessionManagementLookup()
    {
        // do some async lookup
        Action<object> d = delegate(object val)
        {
            LookupSession(); // long running thing that looks up the user.
            Session["UserID"] = 1234; // Setting session manually
        };
    
        d.BeginInvoke(null,null,null);               
    }
