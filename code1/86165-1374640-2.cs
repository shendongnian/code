    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Program
    {
    	static void Main()
    	{
    		String xml = @"<Pricing>
    			<MPrice>
    			    <Id>0079</Id>
    			    <Price>
    				<Price>31.25</Price>
    				<StartDt>2009-8-01</StartDt>
    				<EndDt>2009-08-26</EndDt>
    			    </Price>
    			    <Price>
    				<ListPrice>131.25</ListPrice>
    				<StartDt>2009-08-26</StartDt>
    				<EndDt>9999-12-31</EndDt>
    			    </Price>
    			</MPrice>
    		   </Pricing>";
    
    		var priceInfo = from e in XElement.Parse(xml).Elements("MPrice").Elements("Price")
    				let start = DateTime.Parse(e.Descendants("StartDt").FirstOrDefault().Value)
    				let end = DateTime.Parse(e.Descendants("EndDt").FirstOrDefault().Value)
    				where start < DateTime.Now && end > DateTime.Now
    				select new { Id = e.Parent.Element("Id").Value, ListPrice = e.Element("ListPrice").Value };
    
    		Console.WriteLine(priceInfo.FirstOrDefault().Id);
    		Console.WriteLine(priceInfo.FirstOrDefault().ListPrice);
    	}
    }
