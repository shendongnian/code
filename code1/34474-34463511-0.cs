                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(this.All);
                string language = string.Empty;
                var nodes = doc.DocumentNode.SelectNodes("//html");
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (nodes[i] != null && nodes[i].Attributes.Count > 0 && nodes[i].Attributes.Contains("lang"))
                    {
                        language = nodes[i].Attributes["lang"].Value; //Get attribute
                        nodes[i].Attributes["lang"].Value = "en-US"; //Set attribute
                    }
                }
