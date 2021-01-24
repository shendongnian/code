    public class Script
    {
        //See help for a definition of CustomScriptArguments.
        public CustomScriptReturn CustomScript(CustomScriptArguments args, object sender, EventArgs e)
        {
            // retrieve page from current handler
            var page = HttpContext.Current.CurrentHandler as Page;
            if (page == null)
            {
                // do something, e.g. throw exception
            }
    
            // Place your script code here.
            // Return empty for no special action.
            string response = args.DataRow["Token"];
            string script = "verifyCallback('" + response + "');";
            // call ClientScript from existing page instance
            page.ClientScript.RegisterStartupScript(page.GetType(), "verifyCallback", script, true);
            return CustomScriptReturn.Empty();
        }
    }
