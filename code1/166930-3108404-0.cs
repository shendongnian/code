    // XElement sourceElement contains the original "Books" element.
    var matchingBookGroups = 
        from x in sourceElement.Elements("Book")
        group x by string.Format("{0}-{1}", x.Element("Id").Value, x.Element("EndDate").Value) into g
        select new { Key = g.Key, Values = g };
	
    XElement result =
        new XElement("Books",
            from matchingBookElements in matchingBookGroups
            let firstMatchingBookElement = matchingBookElements.Values.First()
            select
                new XElement("Book",
                    firstMatchingBookElement.Element("Id"),
                    firstMatchingBookElement.Element("EndDate"),
                    firstMatchingBookElement.Element("Price"),
                        new XElement("tag1", string.Join(",", matchingBookElements.Values.Elements("tag1").Select(x => x.Value).ToArray())),
                        new XElement("tag2", string.Join(",", matchingBookElements.Values.Elements("tag2").Select(x => x.Value).ToArray()))));
