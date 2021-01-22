    int? customerId = null;
    if (textbox1.Text != "")
    {
        customerId = int.Parse(textbox1.Text);
    }
    XDocument db = XDocument.Load(xmlPath);
    var query = (from vals in db.Descendants("Customer")
                 where (customerId != null && 
                    (int) vals.Element("CustomerID") == customerId) ||
                    (textbox2.Text != "" && 
                     (string) vals.Element("Name") == textbox2.Text)
                 select vals).ToList();
