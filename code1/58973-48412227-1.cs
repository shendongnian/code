    ...
        IHttpHandler page = HttpContext.Current.Handler;
        if (page is System.Web.UI.Page)
        {
            MasterBase masterPage = (MasterBase)((System.Web.UI.Page)page).Master;
            if (masterPage != null)
                masterPage.MyProperty = "New Value";
        }
    ...
