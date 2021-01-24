    using (ClientContext context = new ClientContext("https://sharepoint.domain.com"))
    {
        context.Load(context.Web, w => w.ServerRelativeUrl);
        context.ExecuteQuery();
        List list = context.Web.GetList($"{context.Web.ServerRelativeUrl.TrimEnd('/')}/Shared Documents");
    }
