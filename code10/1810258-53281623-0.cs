    class Thing
    { 
       public string نام {get;set;}
       // Etc
    }
    List<Thing> items = new List<Thing>(); // <- should be a class member variable, not a local variable
    XDocument xdoc = XDocument.Load("demo.xml");
    var newItems = from key in xdoc.Descendants("user")
                     where key != null && (key.Element("clientno").Value == recieveddata)
                     select new Thing
                     {
                         نام = key.Element("name").Value +" "+ key.Element("lastname").Value,
                       ورزش = key.Element("noeozviat").Value,
                        تاریخ = key.Element("date").Value,
                         عضویت = key.Element("duration").Value,
                        جلسات = key.Element("jalasat").Value
                     };
    items.AddRange(newItems.ToList());
    dataGridView1.Invoke(new Action(() => dataGridView1.DataSource = items));
