    var images = document.DocumentNode.Descendants("img").ToList();
    var nodesToRemove = new List<HtmlNode>();
    foreach (var image in images)
    {
        var parent = image.ParentNode;
        if (parent.Name.Equals("a"))
        {
            nodesToRemove.Add(parent);
        }
    }
