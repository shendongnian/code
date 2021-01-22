    string testXML = @"<p><entry><author>TestAuthor1</author><msg>TestMsg1</msg></entry></p>";
    XElement xmlDoc = XElement.Parse(testXML);
    var query = from entry in xmlDoc.Descendants("entry")
                select new MergeEntry
                {
                    author = entry.Element("author").Value,
                    message = entry.Element("msg").Value,
                }; //You were missing the ";" in your post, I am assuming that was a typo.
    
    //I first binded to a List, that worked fine. I then changed it to use a BindingList
    //to support two-way binding.
    var queryAsList = new BindingList<MergeEntry>(query.ToList());
    bindingSource1.DataSource = queryAsList;
    dataGridView1.DataSource = bindingSource1;
