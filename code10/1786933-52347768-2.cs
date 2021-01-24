    [System.Web.Http.HttpPost]  // Important: it is not System.Web.Mvc.HttpPost
    public void MyMethod([FromBody] MyMethodPostJson arr)
    {
        ...
    }
