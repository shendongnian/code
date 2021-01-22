    public static string T(string search) {
        System.Resources.ResourceManager resMan = new System.Resources.ResourceManager(typeof(WebApplication1.Resources.Locales));
    
        var text = resMan.GetString(search, CultureInfo.GetCultureInfo("en-us"));
    
        if (text == null)
            return "null";
        else if (text == string.Empty)
            return "empty";
        else
            return text;
    }
