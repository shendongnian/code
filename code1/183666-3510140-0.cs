    Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";
        if (!EmployeeSession.IsAuthenticated || EmployeeSession.GetEmployeeType != 1 && EmployeeSession.GetEmployeeType != 2)
            Response.Redirect("Default.aspx");
