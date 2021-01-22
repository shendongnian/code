    public enum Enviroments
	{   
		Dev,
		Qa1,
		Prod1,
		Prod2,
		Uat
	}
        XDocument settings = XDocument.Load("Foo.xml");
    
    	var matches = from e in settings.Descendants("Environment")
    where Enum.IsDefined(typeof (Enviroments), e.Attribute("name"))
    select e;
