    public class Compo 	{
    	public string alim_code { get; set; }
    	public string const_code { get; set; }
    	public string teneur { get; set; }
    	public string min { get; set; }
    	public string max { get; set; }
    	public string code_confiance { get; set; }
    	public string source_code { get; set; }
    }
    
    private void ReadCompoWithLinq() {
    		const string FILENAME = "test.xml";
    		XDocument doc = XDocument.Load(FILENAME);
    
    		List<Compo> compos = doc.Descendants("COMPO").Select(x => new Compo()
    		{
    			alim_code = (string)x.Element("alim_code"),
    			const_code = (string)x.Element("const_code"),
    			teneur = (string)x.Element("teneur"),
    			min = (x.Element("min").Attribute("missing") != null) ? null : (string)x.Element("min"),
    			max = (x.Element("max").Attribute("missing") != null) ? null : (string)x.Element("max"),
    			code_confiance = (string)x.Element("code_confiance"),
    			source_code = (x.Element("source_code").Attribute("missing") != null) ? null : (string)x.Element("source_code"),
    		}).ToList();
    }
