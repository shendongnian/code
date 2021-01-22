    var query = db.Descendants("Customer");
    if (textbox1.Text != null)
    {
        int customerId = int.Parse(textbox1.Text);
        query = query.Where(x => (int) x.Element("CustomerID") == customerId);
    }
    if (textbox2.Text != null)
    {
        query = query.Where(x => (string) x.Element("Name") == textbox2.Text);
    }
    List<XElement> results = query.ToList();
