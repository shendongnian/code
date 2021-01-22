    XDocument xdoc = XDocument.Load("c:\\isbn.xml");
            var items = from item in xdoc.Descendants("BookData")
                        select new
                        {
                            Title = item.Element("Title").Value,
                            AuthTexts = item.Element("AuthorsText").Value
                        };
            foreach (var item in items)
            {
                listView1.Items.Add(new { Title = item.Title, Author = item.AuthTexts });
            }
