                string htmlContents = new System.IO.StreamReader(resultsStream,Encoding.UTF8,true).ReadToEnd();
    
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlContents);
                if (doc == null) return null;
    
                string output = "";
                foreach (var node in doc.DocumentNode.ChildNodes)
                {
                    output += node.InnerText;
                }
