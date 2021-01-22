    [WebMethod]
    [ScriptMethod(ResponseFormat= ResponseFormat.Json)]
    public static List<TopCompany> GetCompanies()
    {
        System.Threading.Thread.Sleep(5000);
        List<TopCompany> allCompany = new List<TopCompany>();
        using (MyDatabaseEntities dc = new MyDatabaseEntities())
        {
            allCompany = dc.TopCompanies.ToList();
        }
        return allCompany;
    }
