    private HtmlGenericControl RenderMenu(Nodes nodes)
    {
        if (nodes == null)
            return null;
    
        var ul = new HtmlGenericControl("ul");
    
        foreach (Node node in nodes)
        {
            var li = new HtmlGenericControl("li");
            li.InnerText = node.Name;
    
            if(node.Children != null)
            {
                li.Controls.Add(RenderMenu(node.Children));
            }
    
            ul.Controls.Add(li);
        }
    
        return ul;
    }
