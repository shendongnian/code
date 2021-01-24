    private void Button_Click(object sender, EventArgs e)
    {
        XDocument xDoc = XDocument.Load(@"Path to your xml file");
    
        string buttonText = (sender as Button).Text;
    
        string description = xDoc.Descendants("template").Where(x => x.Element("name").Value == buttonText).Select(x => x.Element("description").Value).FirstOrDefault();
    
        var listofItems = xDoc.Descendants("template").Where(x => x.Element("name").Value == buttonText).SelectMany(x => x.Elements("item")).Select(y => new Item1 { Id = y.Attribute("id").Value, Name = y.Value });
    
        Form4 form = new Form4();
    
        form.Description = description;
        form.Items = listofItems;
    
        form.ShowDialog();
    }
