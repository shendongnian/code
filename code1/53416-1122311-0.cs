    protected override void OnPreInit(EventArgs e)
    {
        if (string.Compare(Request.ServerVariables["HTTPS"], "OFF", true) == 0)
        {
            StringBuilder builder = new StringBuilder("https://");
            builder.Append(Request.ServerVariables["SERVER_NAME"]);
            builder.Append(Request.ServerVariables["URL"]);
            Response.Redirect(builder.ToString());
            return;
        }
        base.OnPreInit(e);
    }
