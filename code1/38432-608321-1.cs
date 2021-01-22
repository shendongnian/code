                HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("YOUR_TAG_SELECTOR");
                if (nodes != null)
                {
                    foreach (HtmlNode node in nodes)
                    {
                        if (node.InnerHtml.ToLower().Trim() == "YOUR_MATCH")
                        {
                            //success routine
                            break;
                        }
                    }
                }
