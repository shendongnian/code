    System.Collections.Hashtable ht = new System.Collections.Hashtable();
    ht.Add("Url", HttpContext.Current.Request.Url.AbsolutePath.ToLower());
					
    XmlNode currentpage = Core.FindChildNode(item, "MenuItem", ht);
    if (HttpContext.Current.Request.RawUrl.ToLower() == item.Attributes["Url"].Value.ToLower() || currentpage != null)
    {
         writer.AddAttribute(HtmlTextWriterAttribute.Class, "current");
    }
