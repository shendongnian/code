    var items = from item in xdoc.Descendants("Book")
                select new Book                                   //  <---
                {
                    ISBN = (string)item.Element("ISBN"),
                    Title = (string)item.Element("Title"),
                    Author = (string)item.Element("Author"),
                };
    foreach (var item in items)
    {
        listView1.Items.Add(item);
    }
