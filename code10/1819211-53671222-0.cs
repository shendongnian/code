    var web = new HtmlWeb();
            var doc = web.Load(url);
            foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table"))
            {   
                foreach (HtmlNode row in table.SelectNodes("tr"))
                {
                    temprow = new List<string>();
                    foreach (HtmlNode cell in row.SelectNodes("td"))
                    {
                        temprow.Add(cell.InnerText);
                    }
                    rows.Add(temprow);
                }
            }
