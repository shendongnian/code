            var table = htmlDocument.DocumentNode.Descendants("tbody")
            .FirstOrDefault(node => node.GetAttributeValue("class", " ")
            .Equals("standingEntriesContainer") && node.ChildNodes.Count > 0);
            foreach (var tr in table.ChildNodes)
            {
                Console.Write(tr.ChildNodes[0].Descendants("span").FirstOrDefault().InnerText);
                Console.Write(tr.ChildNodes[1].Descendants("a").FirstOrDefault().InnerText);
                Console.Write(tr.ChildNodes[2].InnerText);
                Console.Write(tr.ChildNodes[3].InnerText);
                Console.Write(tr.ChildNodes[4].InnerText);
            }
