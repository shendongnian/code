    [ValidateInput(false)]//This line is to let you pass html in parameters.
    public ActionResult ThisAction(string htmlString)
    {
        StringBuilder sbHtmlString = new StringBuilder();
    
        // Encode the htmlString.
        sbHtmlString.Append(HttpUtility.HtmlEncode(htmlString));
    
        // Only decode bold tag and ignore anything else!
        sbHtmlString.Replace("&lt;b&gt;", "<b>");
        sbHtmlString.Replace("&lt;/b&gt;", "</b>");
        htmlString = sbHtmlString.ToString();
        //Do whatever you want with htmlString 
        return View();
    }
