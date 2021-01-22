 public List<Company> GetContactList(int startindex)
    {
       
        string path = Server.MapPath("~/contacts.xml");
        XDocument xd = XDocument.Load(path);
        IEnumerable<Company> results = (from items in xd.Elements("Company").Elements("Contact")
                       select new Company
                       {
                           Id = items.Element("ID").Value,
                           Photo = (string)items.Element("photo").Value,
                           Name = (string)items.Element("Name").Value,
                           BloodGroup = (string)items.Element("Bg").Value,
                           Dob = (string)items.Element("dob").Value,
                           Anniversery = (string)items.Element("avd").Value,
                           Mobile = (string)items.Element("cnum").Value,
                           designation = (string)items.Element("desig").Value,
                           Team = (string)items.Element("team").Value
                       }).Skip(startindex*10).Take(10);
        return (List<Company>) results;
    }
  </pre>
