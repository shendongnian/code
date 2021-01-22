    public static void Show(string message)
    {
        // Cleans the message to allow single quotation marks
        string cleanMessage = message.Replace("'", "\\'");
        string script = "<script type=\"text/javascript\">alert('" + cleanMessage + "');</script>";
    
        // Gets the executing web page
        Page page = HttpContext.Current.CurrentHandler as Page;
    
        if (page != null)
        {
            ScriptManager.RegisterClientScriptBlock(page, typeof(Alert), "alert", script, false);
        }
    
    }
