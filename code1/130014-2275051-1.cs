    public static string submit(Dictionary<string, string> d)
    {
        if ((string errs = FormValidate(d))!= null) { return errs; }
        // process form
    }
