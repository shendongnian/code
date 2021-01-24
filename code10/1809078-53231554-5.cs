    using System;
    using System.Xml.Linq;
    using System.Xml.XPath;
    public class Program
    {
    	public static void Main()
    	{
    		string _xml = @"<Test xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:xsi='http://www.w3.org/2001/XMLSchemS-instance' xmlns:user='urn:my-scripts' xmlns:msxsl='urn:schemas-microsoft-com:xslt'>
      <FeedTest>
        <ActionId xsi:nil='true' />
        <ReplyToMessageId>12345</ReplyToMessageId>
        <Source>PAPER</Source>
        <Condition />
        <FixingRate xsi:nil='true' />
        <CatsId>TAAH20181105X0000579</CatsId>
      </FeedTest>
    </Test>";
    		XDocument doc = XDocument.Parse(_xml);
    		var catIdText = doc.Root.Element("FeedTest").Element("CatsId").Value;
    		Console.WriteLine(catIdText);
            // update or use XPath to update...
		    doc.Root.Element("FeedTest").Element("CatsId").Value = catIdText+"Happy day";
		    //doc.XPathSelectElement("//Test/FeedTest/CatsId").Value =catIdText+"Happy day";
		    var catIdUpdatedText = doc.Root.Element("FeedTest").Element("CatsId").Value;
		    Console.WriteLine(catIdUpdatedText);
            // save it again:
            string filePath = @"C:\FileMessageTemplates\Outright\"; //File path
            string path = Path.Combine(filePath ,"First_Test_NEW.xml");
            xdoc.Save(path);
    	}
    }
