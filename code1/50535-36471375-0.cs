    public string StripTags(HtmlNode documentNode, IList keepTags)
    {
        var result = new StringBuilder();
            foreach (var childNode in documentNode.ChildNodes)
            {
                if (childNode.Name.ToLower() == "#text")
                {
                    result.Append(childNode.InnerText);
                }
                else
                {
                    if (!keepTags.Contains(childNode.Name.ToLower()))
                    {
                        result.Append(StripTags(childNode, keepTags));
                    }
                    else
                    {
                        result.Append(childNode.OuterHtml.Replace(childNode.InnerHtml, StripTags(childNode, keepTags)));
                    }
                }
            }
            return result.ToString();
        }
