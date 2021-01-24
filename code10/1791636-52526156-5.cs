    public ActionResult Index(string sortOrder)
    {
    	XmlDocument doc = new XmlDocument();
        doc.Load("C:\\Users\\Matt.Dodson\\Desktop\\SampleWork\\PersonsApplicationFromXMLFile\\PersonsApplicationFromXMLFile\\DAL\\Personal.xml");
        IEnumerable<Personal> persons = doc.SelectNodes("/Persons/record")
        	.Cast<XmlNode>()
        	.Select(node => new Personal()
        	{
        		ID = node["ID"].InnerText,
        		Name = node["Name"].InnerText,
        		Email = node["Email"].InnerText,
        		DateOfBirth = node["DateOfBirth"].InnerText,
        		Gender = node["Gender"].InnerText,
        		City = node["City"].InnerText
        	});
        switch (sortOrder)
        {
        	case "ID":
        		persons = persons.OrderBy(Personal => Personal.ID);
        		break;
        	case "Name":
        		persons = persons.OrderBy(Personal => Personal.Name);
        		break;
        	case "City":
        		persons = persons.OrderBy(Personal => Personal.City);
        		break;
        	default:
        		break;
        }
        return View(persons.ToList());
    }
