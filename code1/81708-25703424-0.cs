            HtmlDocument doc = new HtmlDocument
                               {
                                   OptionFixNestedTags = true,
                                   OptionOutputAsXml = true
                               };
            doc.LoadHtml(str);
            // Script comments from the document. 
            if (doc.DocumentNode != null)
            {
                HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//comment()");
                if (nodes != null)
                {
                    foreach (HtmlNode node in from cmt in nodes
                                              where (cmt != null
                                                     && cmt.InnerText != null
                                                     && !cmt.InnerText.ToUpper().StartsWith("DOCTYPE"))
                                                     && cmt.ParentNode != null
                                              select cmt)
                    {
                        node.ParentNode.RemoveChild(node);
                    }
                }
            }
