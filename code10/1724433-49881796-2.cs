    private static NameValueCollection queryString;
    public static NameValueCollection QueryString
    {
        get
        {
            if (queryString == null)
            {
                NameValueCollection nameValueTable = new NameValueCollection();
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    var q = ApplicationDeployment.CurrentDeployment.ActivationUri.Query;
                    nameValueTable = HttpUtility.ParseQueryString(q);
                }
                queryString = nameValueTable;
            }
            return queryString;
        }
    }
