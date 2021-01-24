    if (masterInfo == null)
    {
        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Info");
    }
    else
    {
        return Request.CreateResponse(HttpStatusCode.OK, new { MasterInfo = masterInfo, MasterDepartment = masterDepartment });
        //OR
        //return Request.CreateResponse(HttpStatusCode.OK, new { masterInfo, masterDepartment });
    }
