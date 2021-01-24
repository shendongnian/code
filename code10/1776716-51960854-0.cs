    [HttpGet]
    [ActionName("GetPrint")]
    [ResponseType(typeof(HttpResponseMessage))]
    public IHttpActionResult GetPrint(string templateName, int personId, int badgeId, string authToken, string ipAddress)
    {
        var bdgBl = PeliquinIOC.Instance.Resolve<IBadgeDesignBL>(UserId, UserName, PropertyCode, PartitionName, IpAddress);
        //var apiRsp = new PeliquinApiRsp();
    
        if (!(IsAllowed(SysPrivConstants.SYSPRIV__TYPE_PERSONNEL, templateName, SysPrivConstants.SYSPRIV__LEVEL_READ)))
        {
            return (Unauthorized());
        }
    
        var bdgDto = bdgBl.GetPrint(templateName, personId, badgeId);
    
        if (bdgDto == null)
        {
            return (Unauthorized());
        }
    
    	return File(bdgDto, "application/pdf", "yourPdfName.pdf");
    }
