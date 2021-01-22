            XDocument doc = XDocument.Parse(xml);
            var query = from item in doc.Descendants("item")
                        select new
                        {
                            att1 = (string)item.Attribute("att1"),
                            att2 = (string)item.Attribute("att2") // if needed
                        } into node
                        group node by node.att1 into grp
                        select new { att1 = grp.Key, Count = grp.Count() };
            foreach (var item in query.OrderByDescending(x=>x.Count).Take(4))
            {
                Console.WriteLine("{0} = {1}", item.att1, item.Count);
            }
