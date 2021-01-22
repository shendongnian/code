    public static string InnerText(this XElement el)
    {
        StringBuilder str = new StringBuilder();
        foreach (XNode element in el.DescendantNodes().Where(x=>x.NodeType==XmlNodeType.Text))
        {
            str.Append(element.ToString());
        }
        return str.ToString();
    }
