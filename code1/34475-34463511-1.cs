                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(this.All);
                string language = string.Empty;
                var nodes = doc.DocumentNode.SelectNodes("//html");
                foreach (HtmlNode a in nodes)
                {
                    if (a != null && a.Attributes.Count > 0 && a.Attributes.Contains("lang"))
                    {
                        language = a.Attributes["lang"].Value;
                    }
                }
