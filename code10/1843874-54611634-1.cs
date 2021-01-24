            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table"))
            {
                Console.WriteLine("Table: ");
                foreach (HtmlNode tbody in table.SelectNodes("tbody"))
                {
                    if (tbody.ChildNodes.Any(x => x.Name == "tr"))
                    {
                        Console.WriteLine("TBody: ");
                        foreach (HtmlNode cell in tbody.SelectNodes("tr"))
                        {
                            Console.WriteLine("TR: ");
                            if (cell.ChildNodes.Any(c => c.Name == "td"))
                            {
                                foreach (var item in cell.SelectNodes("td"))
                                {
                                    Console.WriteLine("TD: ");
                                    Console.WriteLine(item.InnerHtml);
                                }
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
