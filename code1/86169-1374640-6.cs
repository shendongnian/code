    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Program
    {
    	static void Main()
    	{
    		XDocument document = XDocument.Load(@"d:\test.xml");
    
    		var priceInfo = from e in document.Descendants("MPrice").Elements("Price")
    				let start = DateTime.Parse(e.Descendants("StartDt").FirstOrDefault().Value)
    				let end = DateTime.Parse(e.Descendants("EndDt").FirstOrDefault().Value)
    				where start < DateTime.Now && end > DateTime.Now
    				select new { Id = e.Parent.Element("Id").Value, ListPrice = e.Element("ListPrice").Value };
    
    		Console.WriteLine(priceInfo.FirstOrDefault().Id);
    		Console.WriteLine(priceInfo.FirstOrDefault().ListPrice);
    	}
    }
