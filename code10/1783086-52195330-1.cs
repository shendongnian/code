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
                break;
            }
        }
        return CurrentProfileDLS;
    }
