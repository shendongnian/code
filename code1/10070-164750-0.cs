    public void SomeProprietarySessionManagementLookup()
    {
        // do some async lookup
        Action<object> d = delegate(object val)
        {
            // long running thing that looks up the user.
            Session["UserID"] = 1234;
        };
    
        d.BeginInvoke(null,null,null);               
    }
