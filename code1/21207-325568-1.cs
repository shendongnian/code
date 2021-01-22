        StringBuilder result = new StringBuilder();
        foreach (IRSSable item in rss)
        {
            result.Append("<item>").Append(item.GetRSSItem().InnerXml).Append("</item>");
        }
        return result.ToString();
