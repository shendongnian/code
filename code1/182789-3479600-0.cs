    HtmlElementCollection links = webBrowser.Document.GetElementsByTagName("A");
                
    foreach (HtmlElement link in links)
    {
    	if (link.InnerText.Equals("My Assigned"))
    		link.InvokeMember("Click");
    }
