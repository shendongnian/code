            List<HelpItem> helpitems = (from helpitem in myData.Descendants("HelpItem")
                      select new HelpItem
                      {
                           Category = helpitem.Element("Category").Value,
                           Question = helpitem.Element("Question").Value,
                           Answer = helpitem.Element("Answer").Value,
                      }).ToList<HelpItem>();
