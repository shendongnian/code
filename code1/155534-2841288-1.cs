    XDocument xmlDoc = XDocument.Load("emails.xml");            
    
    var t = from c in xmlDoc.Descendants("dt")
    select new
    {
        Name = e.Element("name").Value,
        EMail = e.Element("email").Value,
    };
    foreach (var item in t)
    {                   
        var lvi = listView.Items.Add(item.Name);
        lvi.SubItems.Add(item.EMail);
    } 
