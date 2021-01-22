    protected void Application_Start()
    {
        RegisterRoutes(RouteTable.Routes);
        WhateverClass.TheData = loadDataFromSql();
    }
