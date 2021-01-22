    public static class MessageBox
    {
        //StringBuilder to hold our client-side script
        private static StringBuilder builder;
    
        public static void Show(string message)
        {
            //initialize our StringBuilder
            builder = new StringBuilder();
    
            //format script by replacing characters with JavaScript compliant characters
            message = message.Replace("\n", "\\n");
            message = message.Replace("\"", "'");
    
            //create our client-side script
            builder.Append("<script language=\"");
            builder.Append("javascript\"");
            builder.Append("type=\"text/javascript\">");
            builder.AppendFormat("\t\t");
            builder.Append("alert( \"" + message + "\" );");
            builder.Append(@"</script>");
    
            //retrieve calling page
            Page page = HttpContext.Current.Handler as Page;
    
            //add client-side script to end of current response
            page.Unload += new EventHandler(page_Unload);
        }
    
        private static void page_Unload(object sender, EventArgs e)
        {
            //write our script to the page at the end of the current response
            HttpContext.Current.Response.Write(builder);
        }
    }
