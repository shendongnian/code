    HtmlElement tableElement = FindElement(HtmlDocument.Body, "table");
    foreach(HtmlElement row in tableElement.Children)
    {
        if (row.Name.ToLower() == "tr")
        {
            // create whatever class you use for a row
            foreach(HtmlElement cell in row.Children)
            {
                if (cell.Name.ToLower() == "td")
                {
                    // add a new cell to your row using cell.InnerText
                }
            }
        }
    }
    // *** snip ***
    
    private HtmlElement FindElement(HtmlElement element, string name)
    {
        if (element.Name.ToLower() == name)
        {
            return element;
        }
        foreach(HtmlElement child in element.Children)
        {
            HtmlElement test = FindElement(test, name);
            if (test != null)
            {
                return test;
            }
        }
        return null;
    }
