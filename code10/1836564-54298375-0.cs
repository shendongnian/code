            var xml = XDocument.Load(@"C:\temp\xml.xml");
            var ds = xml.Root.Descendants("Shop")
                    .Single(x => x.Attribute("name").Value == "Tiarga")
                    .Descendants("Item")
                    .Select(x=> new {
                        Name = x.Attribute("name").Value,
                        Price = x.Descendants("Price").FirstOrDefault()?.Value,
                        Stats = x.Descendants("Stats").FirstOrDefault()?.Value,
                        Quantity = x.Descendants("Quantity").FirstOrDefault()?.Value,
                    })
                    .ToList();
            dataGridView1.DataSource = ds;
