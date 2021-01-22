    class ExtensionObject
    {
        public string HtmlEncode(string input)
        {
            return System.Web.HttpUtility.HtmlEncode();
        }
    }
    //...
    XsltArgumentList arguments = new XsltArgumentList();
    arguments.AddExtensionObject("my:HttpUtility", new ExtensionObject());
    
        
