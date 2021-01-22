    // your data, probably comes from somewhere, or as params to a method
    int lengthAvailable = 20;
    XmlDocument xml = new XmlDocument();
    xml.LoadXml(@"place-html-code-here-left-out-for-brevity");
    
    // create a navigator, this is our primary tool
    XPathNavigator navigator = xml.CreateNavigator();
    XPathNavigator breakPoint = null;
    
    
    string lastText = "";
    
    // find the text node we need:
    while (navigator.MoveToFollowing(XPathNodeType.Text))
    {
        lastText = navigator.Value.Substring(0, Math.Min(lengthAvailable, navigator.Value.Length));
        lengthAvailable -= navigator.Value.Length;
    
        if (lengthAvailable <= 0)
        {
            // truncate the last text. Here goes your "search word boundary" code:
            navigator.SetValue(lastText);
            breakPoint = navigator.Clone();
            break;
        }
    }
    
    // first remove text nodes, because Microsoft unfortunately merges them without asking
    while (navigator.MoveToFollowing(XPathNodeType.Text))
        if (navigator.ComparePosition(breakPoint) == XmlNodeOrder.After)
            navigator.DeleteSelf();   // moves to parent
    
    // then move the rest
    navigator.MoveTo(breakPoint);
    while (navigator.MoveToFollowing(XPathNodeType.Element))
        if (navigator.ComparePosition(breakPoint) == XmlNodeOrder.After)
            navigator.DeleteSelf();   // moves to parent
    
    // then remove *all* empty nodes to clean up (not necessary): 
    // TODO, add empty elements like <br />, <img /> as exclusion
    navigator.MoveToRoot();
    while (navigator.MoveToFollowing(XPathNodeType.Element))
        while (!navigator.HasChildren && (navigator.Value ?? "").Trim() == "")
            navigator.DeleteSelf();  // moves to parent
    
    navigator.MoveToRoot();
    Debug.WriteLine(navigator.InnerXml);
