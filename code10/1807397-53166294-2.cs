    public static CustomScriptReturn CustomScript(CustomScriptArguments args)
    {
        // retrieve page from current handler
        var page = System.Web.HttpContext.Current.CurrentHandler as Page;
        if (page == null)
        {
            // do something, e.g. throw exception
        }
        // Place your script code here.
        // Return empty for no special action.
        string response = args.DataRow["Captcha"];
        string script = "page.verifyCallback('" + response + "');";
        // call ClientScript from existing page instance
        page.ClientScript.RegisterStartupScript(page.GetType(), "page.verifyCallback", script, true);
        return CustomScriptReturn.Empty();
    }
