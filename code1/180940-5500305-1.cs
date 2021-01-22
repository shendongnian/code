    HtmlElementCollection theElementCollection = default(HtmlElementCollection);
    theElementCollection = webBrowser1.Document.GetElementsByTagName("span");
    foreach (HtmlElement curElement in theElementCollection)
    {
        if (curElement.GetAttribute("className").ToString() == "example")
        {
            MessageBox.Show(curElement.GetAttribute("InnerText")); // Do something you want
        }
    }
