      public XmlDocument GetRss(int count)
        {
            XmlDocument xml=new XmlDocument();
          	XmlElement root,chn,elm;
		    xml.AppendChild(xml.CreateXmlDeclaration("1.0", "utf-8", "yes"));
		    root = xml.CreateElement("rss");
		    root.SetAttribute("version", "2.0");
		    xml.AppendChild(root);
		    chn = xml.CreateElement("channel");
		    root.AppendChild(chn);
		    elm = xml.CreateElement("title");
            elm.InnerText = System.Web.Configuration.WebConfigurationManager.AppSettings["sitename"];
		    chn.AppendChild(elm);
		    elm = xml.CreateElement("link");
            elm.InnerText = System.Web.Configuration.WebConfigurationManager.AppSettings["host"];
		    chn.AppendChild(elm);
		    elm = xml.CreateElement("description");
            elm.InnerText = System.Web.Configuration.WebConfigurationManager.AppSettings["sitedes"] ;
            chn.AppendChild(elm);
            List<Blog> blogs = BlogManager.Instance.GetBlogLists(count);
            foreach (Blog bg in blogs)
            {
                Blog blog=BlogManager.Instance.ReadBlog(bg.keyword,bg.path);
                if (blog.encryption.Trim() == string.Empty)
                {
                    XmlElement item = xml.CreateElement("item");
                    chn.AppendChild(item);
                    elm = xml.CreateElement("title");
                    item.AppendChild(elm);
                    elm.InnerText = blog.title;
                    elm = xml.CreateElement("pubDate");
                    item.AppendChild(elm);
                    elm.InnerText = blog.pubdate.ToString("r");
                    elm = xml.CreateElement("link");
                    item.AppendChild(elm);
                    elm.InnerText = System.Web.Configuration.WebConfigurationManager.AppSettings["host"] + "Blog/"+bg.path+"/" + blog.keyword + ".esp";
                    elm = xml.CreateElement("description");
                    item.AppendChild(elm);
                    elm.AppendChild(xml.CreateCDataSection(blog.description));
                    elm = xml.CreateElement("guid");
                    item.AppendChild(elm);
                    elm.InnerText = System.Web.Configuration.WebConfigurationManager.AppSettings["host"] + "Blog/" + bg.path + "/" + blog.keyword + ".esp";
                    elm.SetAttribute("isPermaLink", "false");
                }
            
            }
            return xml;
        
        }
