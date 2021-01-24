    const string FILENAME = @"c:\temp\test.xml";
    const string DATABASE = @"c:\temp\test1.xml";
    public static void Main(string[] args)
    {
    	XDocument doc = XDocument.Load(FILENAME);
    
    	XElement article = doc.Root;
    	XNamespace ns = article.GetDefaultNamespace();
    
    	XDocument docDatabase = XDocument.Load(DATABASE);
    	XElement rdf = docDatabase.Root;
    	XNamespace nsSkosxl = rdf.GetNamespaceOfPrefix("skosxl");
    	XNamespace nsSkos = rdf.GetNamespaceOfPrefix("skos");
    	XNamespace nsRdf = rdf.GetNamespaceOfPrefix("rdf");
    
    	List<XElement> prefLabels = rdf.Descendants(nsSkos + "Concept").ToList();
    	Dictionary<string, List<string>> dictLabels = prefLabels.GroupBy(x => (string)x.Descendants(nsSkosxl + "literalForm").FirstOrDefault(), y => (string)y.Parent.Element(nsSkos+"Concept").Attribute(nsRdf + "about").Value.Substring(18))
    		.ToDictionary(x => x.Key, y => y.ToList());
    
    	List<XElement> fundingSources = article.Descendants(ns + "funding-source").ToList();
    
    	foreach (XElement fundingSource in fundingSources)
    	{
    		XElement institutionWrap = fundingSource.Element(ns + "institution-wrap");
    		string institution = (string)fundingSource;
    
    		if (dictLabels.ContainsKey(institution))
    		{
    			institutionWrap.Add(new XElement("institution-id", new object[] {
    			                                 	new XAttribute("institution-id-type","fundref"),
    			                                 	dictLabels[institution]
    			                                 }));
    		}
    	}
    	doc.Save(FILENAME);
    	Console.WriteLine("Done");
    	Console.ReadLine();
    }
