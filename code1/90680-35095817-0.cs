                #region // PAGES
                string pages_xmlurl = Server.MapPath(Url.Content("~/xml/pages_" + lng.code + ".xml")).ToString();
                XmlTextWriter pages_XML = new XmlTextWriter(pages_xmlurl, UTF8Encoding.UTF8);
                pages_XML.WriteStartDocument();
                pages_XML.WriteProcessingInstruction("xml-stylesheet", "type='text/xsl' href='gss.xsl'");
                pages_XML.WriteComment("Generator By OS sitemap generator, http://www.oguzhansari.com");
                pages_XML.WriteStartElement("urlset");
                pages_XML.WriteAttributeString("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");
                pages_XML.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                pages_XML.WriteAttributeString("xsi:schemaLocation", "http://www.google.com/schemas/sitemap/0.84");
                pages_XML.WriteEndDocument();
                pages_XML.Close();
                XmlDocument pages_XMLCONTENTS = new XmlDocument();
                pages_XMLCONTENTS.Load(pages_xmlurl);
                var pages = db.pages.Where(w => w.isActive == true & w.isDelete != true).ToList();
                foreach (var pgs in pages)
                {
                    XmlElement _element = pages_XMLCONTENTS.CreateElement("url", pages_XMLCONTENTS.DocumentElement.NamespaceURI);
                    XmlElement loc = pages_XMLCONTENTS.CreateElement("loc", pages_XMLCONTENTS.DocumentElement.NamespaceURI);
                    loc.InnerText = www + Tools.CreateLinkSingleLang("[CORPORATEPAGES]", "[CORPORATEPAGE]", pgs.id, pgs.pages_contents.Where(xw => xw.languageID == lng.id).FirstOrDefault().title, lng.id);
                    _element.AppendChild(loc);
                    XmlElement lastmod = pages_XMLCONTENTS.CreateElement("lastmod", pages_XMLCONTENTS.DocumentElement.NamespaceURI);
                    lastmod.InnerText = DateTime.Now.ToString();
                    _element.AppendChild(lastmod);
                    XmlElement changefreq = pages_XMLCONTENTS.CreateElement("changefreq", pages_XMLCONTENTS.DocumentElement.NamespaceURI);
                    changefreq.InnerText = "daily";
                    _element.AppendChild(changefreq);
                    XmlElement priority = pages_XMLCONTENTS.CreateElement("priority", pages_XMLCONTENTS.DocumentElement.NamespaceURI);
                    priority.InnerText = "0.5";
                    _element.AppendChild(priority);
                    pages_XMLCONTENTS.DocumentElement.AppendChild(_element);
                }
                XmlTextWriter pages_write = new XmlTextWriter(pages_xmlurl, null);
                pages_write.Formatting = Formatting.Indented;
                pages_XMLCONTENTS.WriteContentTo(pages_write);
                pages_write.Close();
                #endregion
