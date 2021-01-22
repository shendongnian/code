    var category = xd.Descendants("PrimaryCategory")
                     .Where(c => (int)c.Element("PrimaryCategoryID") == 3)
                     .Single(); // Could use `FirstOrDefault` if there could be none
    var query = from list in category.Elements("CategoryList")
                select new { Name = list.Element("CategoryName").Value,
                             Url = list.Element("CategoryURL").Value };
