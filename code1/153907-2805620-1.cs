    XDocument lbSrc = XDocument.Load("yourfile.xml");
 
    List<item> _lbList = new List<item>();
    foreach (XElement item in lbSrc.Descendants("item"))
    {
       _lbList.Add(new item { CHK= item.Element("CHK").Value, 
                              SEL = Convert.ToInt32(item.Element("SEL").Value), 
                              VALUE = item.Element("VALUE").Value });
     }
