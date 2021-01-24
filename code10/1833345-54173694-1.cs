    var links = webpage.Document.GetElementsByTagName("button");
    foreach (HtmlElement link in links)
    {
        if (link.GetAttribute("className") == "something")
        {
            link.InvokeMember("click");
        }               
    }
    links = webpage.Document.GetElementsByTagName("button");
    foreach (HtmlElement link in links)
    {
        if (link.GetAttribute("className") == "something")
        {
        while (!link.Enabled) 
            { 
                Application.DoEvents();
                Thread.Sleep(100); 
            }
            link.InvokeMember("click");
        }                
    }
