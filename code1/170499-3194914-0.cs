    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService {
	public WebService()
	{
		//Uncomment the following line if using designed components 
		//InitializeComponent(); 
	}
	[WebMethod]
	public XmlDocument GetApple()
	{
		Apples apples = Report.GetReport();
		//  this returns:
		//  <Apples xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://tempuri.org/">
		//  <Name>Smtih</Name>
		//  <Size>11</Size>
		//  <Weight>111</Weight>
		//  <Color>Red</Color>
		//  </Apples>
		// Serialization
		string serializedXML = SerializeObject(apples);
		string TemplatePath = Server.MapPath("~/Template.xml");
		// this is:
		// <?xml version="1.0" encoding="utf-8" ?>
		// <applereport>
		//  <moretags>
		//    <july>
		//      <report>
		//        <DATA-GOES-HERE></DATA-GOES-HERE>
		//      </report>
		//    </july>
		//  </moretags>
		// </applereport>
		// Read TemplatePath into a memory stream
		// find the node: <DATA-GOES-HERE></DATA-GOES-HERE>
		// 
		// put serialixed output of Report.GetReport() where <DATA-GOES-HERE></DATA-GOES-HERE> is
		XmlDocument xdoc = new XmlDocument();
		xdoc.Load(TemplatePath);
		XmlNodeList datagoeshere = xdoc.GetElementsByTagName("DATA-GOES-HERE");
		if (datagoeshere != null && datagoeshere.Count > 0)
			datagoeshere[0].InnerXml = serializedXML;
		return xdoc;
	}
	/// <summary>
	/// To convert a Byte Array of Unicode values (UTF-8 encoded) to a complete String.
	/// </summary>
	/// <param name="characters">Unicode Byte Array to be converted to String</param>
	/// <returns>String converted from Unicode Byte Array</returns>
	private String UTF8ByteArrayToString(Byte[] characters)
	{
		UTF8Encoding encoding = new UTF8Encoding();
		String constructedString = encoding.GetString(characters);
		return (constructedString);
	}
	/// <summary>
	/// Converts the String to UTF8 Byte array and is used in De serialization
	/// </summary>
	/// <param name="pXmlString"></param>
	/// <returns></returns>
	private Byte[] StringToUTF8ByteArray(String pXmlString)
	{
		UTF8Encoding encoding = new UTF8Encoding();
		Byte[] byteArray = encoding.GetBytes(pXmlString);
		return byteArray;
	}
	/// <summary>
	/// Method to convert a custom Object to XML string
	/// </summary>
	/// <param name="pObject">Object that is to be serialized to XML</param>
	/// <returns>XML string</returns>
	public String SerializeObject(Object pObject)
	{
		try
		{
			//Create our own namespaces for the output
			XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
			//Add an empty namespace and empty value
			ns.Add("", "");
			String XmlizedString = null;
			MemoryStream memoryStream = new MemoryStream();
			XmlSerializer xs = new XmlSerializer(typeof(Apples));
			XmlTextWriter xmlTextWriter = new XmlTextWriterFormattedNoDeclaration(memoryStream, Encoding.UTF8);
			xs.Serialize(xmlTextWriter, pObject, ns);
			memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
			XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
			return XmlizedString.Trim();
		}
		catch (Exception e)
		{
			System.Console.WriteLine(e);
			return null;
		}
	}
	public class XmlTextWriterFormattedNoDeclaration : System.Xml.XmlTextWriter
	{
		public XmlTextWriterFormattedNoDeclaration(Stream w, Encoding encoding)
			: base(w, encoding)
		{
			Formatting = System.Xml.Formatting.Indented;
		}
		public override void WriteStartDocument() { } // suppress
	} }
