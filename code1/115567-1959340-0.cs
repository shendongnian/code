    XDocument xmlDoc = XDocument.Load(@"C:\so.xml");
    // handle Query String variations here - this works for your first case.
    List<Categories> results = (from cats in xmlDoc.Descendants("Category")
                                where cats.Element("Title").Value.ToLower() == "food1"
                                select new Categories
                                {
                                    Title = cats.Element("Title").Value,
                                    Cat = cats.Element("Cat").Value,
                                    Duration = cats.Element("Duration").Value,
                                    Description = cats.Element("Description").Value
                                }).ToList();
