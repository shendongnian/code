You're passing in a value to be set (or nulled) but not using the Out modifier on the parameter. Without knowing exactly why you're passing in CurrentProfileDLS I would suggest a mild modification of 
    private string CopyProfileDLS_Intercept_AddPhone_Unify()
    {
    	string CurrentProfileDLS = null;
        var elmC = web_Browser.Document.GetElementsByTagName("select");
        foreach (HtmlElement elm in elmC)
        {
            if (elm.Id == "DLSProf")
            {
                if (elm.InnerText.Contains("settings"))
                {
                    CurrentProfileDLS = elm.GetAttribute("value");
                }
            }
        }
        return CurrentProfileDLS;
    }
This way you are initializing the field as null and returning it at the end, regardless of if it gets overridden with elm.GetAttribute("value");.
