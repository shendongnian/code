    //get by XPath
    XPathResult xpathResult = _browser.Document.EvaluateXPath("//*[@id]/div/p[2]");
    var foundNodes = xpathResult.GetNodes();
    foreach (var node in foundNodes)
    {
        var x = node.TextContent; // get text text contained by this node (including children)
        GeckoHtmlElement element = node as GeckoHtmlElement; //cast to access.. inner/outerHtml
        string inner = element.InnerHtml;
        string outer = element.OuterHtml;
        //iterate child nodes
        foreach (var child in node.ChildNodes)
        {
        }
    }
    //get by id
    GeckoHtmlElement htmlElementById = _browser.Document.GetHtmlElementById("mw-content-text");
    //get by tag
    GeckoElementCollection byTag = _browser.Document.GetElementsByTagName("input");
    foreach (var ele in byTag)
    {
        var y = ele.GetAttribute("value");
    }
    //get by class
    var byClass = _browser.Document.GetElementsByClassName("input");
    foreach (var node in byClass)
    {
        //...
    }
    //cast to a different object
    var username = ((GeckoInputElement)_browser.Document.GetHtmlElementById("yourUsername")).Value;
    //create new object from DomObject
    var button = new GeckoButtonElement(_browser.Document.GetElementById("myBtn").DomObject);
