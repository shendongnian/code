    foreach(XmlNode item in menuitems)
    {
        if(HttpContext.Current.Request.Url.AbsolutePath.ToLower() == item.Attributes["Url"].Value.ToLower()
            || IsChildSelected(item))
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "current");
        }
        writer.RenderBeginTag(HtmlTextWriterTag.Li);
    }
