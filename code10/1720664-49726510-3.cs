    [HttpPost]
    public void ChangePassword([FromBody]string userName, [FromBody]string oldPassword, [FromBody]string newPassword)
    {
        WebServiceFault fault = _securityManager.ChangePassword(userName, oldPassword, newPassword);
        if (fault == null)
        {
            return;
        }
    
        throw WebApiServiceFaultHelper.CreateFaultException(fault);
    }
