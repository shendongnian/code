    var query = from f in fDoc.Descendants("company")
                        where ((string)f.Attribute("active")).Equals("1")
                        orderby f.Element("name").Value
                        from r in rDoc.Descendants("bill")
                        where (f.Element("category").Value).Split(',').Contains(r.Element("category").Value)
                        group new
                        {
                            BillTotal = Convert.ToInt32(r.Element("total").Value)
                        }
                        by f.Element("name").Value + f.Element("location").Value + f.Element("room").Value into g
                        select new
                        {
                            Name = g.Key,
                            Total = g.Sum(rec => rec.BillTotal),
                        };
