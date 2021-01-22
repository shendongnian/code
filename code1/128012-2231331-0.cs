    public void ProcessRequest (HttpContext context) {
        int iconId;
        if (string.IsNullOrEmpty(context.Request.QueryString["id"]) || !int.TryParse(context.Request.QueryString["id"], out iconId) )
            throw new ArgumentException("No parameter specified");
        context.Response.ContentType = "image/gif";
        var db = new UdINaturen.UdINaturenContext();
        var GetIcon = (from i in db.subcategoryicons
                       where i.id == iconId
                       select i.picture).FirstOrDefault();
        byte[] buffer = GetIcon;
        context.Response.ContentType = "image/gif";
        context.Response.BinaryWrite(buffer);
        context.Response.Flush();
    }
