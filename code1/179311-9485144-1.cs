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
<hr />
The second approach: select only the top `` node of each group, then iterate through each of these nodes to find the next `` node until the first non-`` node. I used `xpath` here:
    var nodes = doc.DocumentNode.SelectNodes(
        "//code[name(preceding-sibling::*[1])!='code']"
    );
    foreach (var node in nodes)
    {
        var pre = HtmlNode.CreateNode("<pre class='brush: csharp'></pre>");
        node.ParentNode.InsertBefore(pre, node);
        var content = string.Empty;
        var next = node;
        do
        {
            content += next.InnerText + Environment.NewLine;
            var previous = next;
            next = next.SelectSingleNode("following-sibling::*[1][name()='code']");
            previous.Remove();
        } while (next != null);
        pre.AppendChild(doc.CreateTextNode(
            content.TrimEnd(Environment.NewLine.ToCharArray())
        ));
    }
