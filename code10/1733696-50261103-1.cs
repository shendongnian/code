    var results =
              root
                .Descendants("SaleGroup")
                .Select(element => new SaleGroup()
                {
                    Active = Convert.ToBoolean(element.Attribute("active").Value),
                    Id = Convert.ToInt32(element.Attribute("id").Value),
                    Name = element.Attribute("name").Value,
                    File = new SaleFile()
                    {
                        Destination = element.Descendants("files").Single().Attribute("destination").Value,
                        FileType = element.Descendants("files").Single().Attribute("fileType").Value,
                        Location = element.Descendants("files").Single().Attribute("location").Value
                    }
                })
                .ToList();
