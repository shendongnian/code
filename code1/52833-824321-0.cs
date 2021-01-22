    HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(htmlMessage);
                
    //This selects all the Image Nodes
                HtmlNodeCollection hrefNodes = htmlDoc.DocumentNode.SelectNodes("//img");
    
                foreach (HtmlNode node in hrefNodes)
                {
                    string imgUrl = node.Attributes["src"].Value;
                    node.Attributes["src"].Value = webAppUrl + imgUrl;
                }
    
    		StringBuilder sb = new StringBuilder();
                StringWriter sw = new StringWriter(sb);
    
                htmlDoc.OptionOutputAsXml = false;
                htmlDoc.Save(sw);
                htmlMessage = sb.ToString();
