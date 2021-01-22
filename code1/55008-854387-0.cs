    private static bool IsChildSelected(XmlNode item)
    {
        foreach(XmlNode child in item.ChildNodes)
        {
            if(HttpContext.Current.Request.Url.AbsolutePath.ToLower() == child.Attributes["Url"].Value.ToLower())
            {
                return true;
            }
        }
        return false;
    }
