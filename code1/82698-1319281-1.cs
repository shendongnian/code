    XNode Highlight(XElement element, List<string> keywords)
    {
        var result = new XElement(element.Name);
        // copy element attributes to result
        foreach (var node in element)
        {
            if (node.Type == NodeType.Text)
            {
                var value = node.Value;
                // while value contains keyword
                // {
                //      add substring before keyword in value to result
                //      add new XElement with highlighted keyword to result
                //      remove consumed substring from value
                // }
            }
            else if (node.Type == NodeType.Element)
            {
                result.Add(Highlight((XElement)node, keywords));
            }
            else
            {
                result.Add(node);
            }
        }
        return result;
    }
    var output = Highlight(XElement.Parse(input), new List<string> {...}).ToString();
