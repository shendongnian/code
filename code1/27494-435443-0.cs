    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString Function1()
    {
        SqlServerProject1.navision.NavisionLink po = new SqlServerProject1.navision.NavisionLink();
        string test = Convert.ToString(po.GetPONumber("NavisionDev"));
        // Put your code here
        return new SqlString(test);
    }
};
