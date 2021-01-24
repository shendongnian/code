    [HttpGet]
    [Route("/something/entities")]
    public IEnumerable<appinfo> GetEntities()
    {
        using (XamarinEntities entities = new XamarinEntities())
            return entities.appinfoes.ToList();
    }
    [HttpGet]
    [Route("/something/properties")]
    public IEnumerable<string> GetProperties()
    {
        return new string[] { "id", "fname", "lname", "phone", "company", "approveduser" };
    }
    [HttpGet]
    [Route("/something/appinfo")]
    public appinfo GetAppInfo(string email)
    {
        using (XamarinEntities entities = new XamarinEntities())
            return entities.appinfoes.FirstOrDefault(e => e.email == email);
    }
