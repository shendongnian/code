    void ErrorLog_Logged(object sender, ErrorLoggedEventArgs args)
    {
        if (args.Entry.Error.Exception is HandledElmahException)
            return;
        
        var config = WebConfigurationManager.OpenWebConfiguration("~");
        var customErrorsSection = (CustomErrorsSection)config.GetSection("system.web/customErrors");        
        if (customErrorsSection != null)
        {
            switch (customErrorsSection.Mode)
            {
                case CustomErrorsMode.Off:
                    break;
                case CustomErrorsMode.On:
                    FriendlyErrorTransfer(args.Entry.Id, customErrorsSection.DefaultRedirect);
                    break;
                case CustomErrorsMode.RemoteOnly:
                    if (!HttpContext.Current.Request.IsLocal)
                        FriendlyErrorTransfer(args.Entry.Id, customErrorsSection.DefaultRedirect);
                    break;
                default:
                    break;
            }
        }        
    }
    void FriendlyErrorTransfer(string emlahId, string url)
    {
        Server.Transfer(String.Format("{0}?id={1}", url, Server.UrlEncode(emlahId)));
    }
