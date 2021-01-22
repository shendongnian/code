    public string GetContentTypeTemplates()
    {
        SPWeb web = SPContext.GetContext(HttpContext.Current).Web;
        web.CheckPermissions(SPBasePermissions.EmptyMask | SPBasePermissions.ManageLists);
        web.CheckPermissions(SPBasePermissions.EmptyMask | SPBasePermissions.AddAndCustomizePages);
        return this.GetGeneralContentTypes(web.AvailableContentTypes);
    }
