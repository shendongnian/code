    using (((WindowsIdentity)HttpContext.Current.User.Identity).Impersonate())
    {
        WCFTestService.ServiceClient myService = new WCFTestService.ServiceClient();
        Response.Write(myService.GetData(123) + "<br/>");
        myService.Close();
    }
