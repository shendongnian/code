    void Main()
    {
    	//Create();
    	View();
        // Output:
        // User1
        // User2
    }
    
    private void Create()
    {
    	string path = "C:\\Code\\Sandbox\\Accounts.xml";
    	XmlDocument doc = new XmlDocument();
    	doc.Load(path);
    	XmlElement root = doc.CreateElement("Login");
    	XmlElement user = doc.CreateElement("user");
    	user.InnerText = "User2";
    	root.AppendChild(user);
    	doc.DocumentElement.AppendChild(root);
    	doc.Save(path);
    	Console.WriteLine("Created SuccesFully!");
    }
    
    private void View()
    {
    	XmlDocument xdoc = new XmlDocument();
    	xdoc.Load("C:\\Code\\Sandbox\\Accounts.xml");
    	foreach (XmlNode person in xdoc.SelectNodes("//Login"))
    	{
    		Console.WriteLine(person["user"].InnerText);
    	}
    }
