        public static class Helpers
        {
    
            public static MvcHtmlString Menu(this HtmlHelper helper, string name, string e = null, object attributes = null)
            {
                string filepath = helper.ViewContext.HttpContext.Server.MapPath(name + ".xml");
    
                XPathDocument oDoc = new XPathDocument(filepath);
    
                return new MvcHtmlString(GetMenuHtml(oDoc.CreateNavigator(), e, attributes));
            }
    
            private static string GetMenuHtml(XPathNavigator nav, string e = "ul", object attributes = null)
            {
    
                List<String> item = new List<String>();
    
                XPathNodeIterator nodes = nav.Select("items/item");
    
                TagBuilder holder = new TagBuilder(e);
    
                if (attributes != null)
                {
                    IDictionary<string, object> htmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(attributes);
                    holder.MergeAttributes(htmlAttributes);
                }
    
                while (nodes.MoveNext())
                {
    
                    TagBuilder a = new TagBuilder("a");
                    TagBuilder span = new TagBuilder("span");
                    TagBuilder li = new TagBuilder("li");
    
                    string url = nodes.Current.GetAttribute("link", string.Empty);
                    string text = nodes.Current.GetAttribute("text", string.Empty);
                    string title = nodes.Current.GetAttribute("title", string.Empty);
    
                    span.InnerHtml = text;
    
                    a.MergeAttribute("href", url);
    
                    if (!String.IsNullOrEmpty(title)) a.MergeAttribute("title", title);
                    
                    a.InnerHtml = span.ToString();
    
                    List<String> classes = new List<String>();
    
                    if (url == HttpContext.Current.Request.Url.AbsolutePath)
                    {
                        classes.Add("active");   
                    }
    
                    if (nodes.Count == nodes.CurrentPosition)
                    {
                        classes.Add("last");
                    }
                    else if (nodes.CurrentPosition == 1)
                    {
                        classes.Add("first");
                    }
    
                    if (nodes.Current.HasChildren)
                    {
                        li.InnerHtml = a.ToString() + GetMenuHtml(nodes.Current, e);
    
                        if (li.InnerHtml.Contains("class=\"active"))
                        {
                            classes.Add("active-trail");
                        }
    
                        classes.Add("leaf");
                    }
                    else
                    {
                        li.InnerHtml = a.ToString();
                    }
    
                    if(classes.Count > 0){
                        li.MergeAttribute("class", string.Join(" ", classes.ToArray()));
                    }
    
                    item.Add(li.ToString() + "\n");
    
                }
    
                holder.InnerHtml = string.Join("", item.ToArray());
    
                return holder.ToString();
    
            }
    
    
        }
