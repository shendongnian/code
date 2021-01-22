The first approach: select all the `` nodes, group them, and create a `<pre>` node per group:
    var idx = 0;
    var nodes = doc.DocumentNode
        .SelectNodes("//code")
        .GroupBy(n => new { 
            Parent = n.ParentNode, 
            Index = n.NextSiblingIsCode() ? idx : idx++ 
        });
    foreach (var group in nodes)
    {
        var pre = HtmlNode.CreateNode("<pre class='brush: csharp'></pre>");
        pre.AppendChild(doc.CreateTextNode(
            string.Join(Environment.NewLine, group.Select(g => g.InnerText))
        ));
        group.Key.Parent.InsertBefore(pre, group.First());
        foreach (var code in group)
            code.Remove();
    }
The grouping field here is combined field of a parent node and group index which is increased when new group is found. 
Also I used `NextSiblingIsCode` extension method here:
    public static bool NextSiblingIsCode(this HtmlNode node)
    {
        return (node.NextSibling != null && node.NextSibling.Name == "code") ||
            (node.NextSibling is HtmlTextNode && 
             node.NextSibling.NextSibling != null && 
             node.NextSibling.NextSibling.Name == "code");
    }
It used to determine whether the next sibling is a `` node.
