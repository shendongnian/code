    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Web;
    
    class Example
    {
    	static void Main()
    	{
    		String xml = @"<div class=""details"">
    			  <a href=""/Details/Empinfo.asp?empid=134"">
    				Employee details</a> 
    			</div>";
    
    		String[] queryString = XElement.Parse(xml)
    			.Descendants("a")
    			.Attributes("href")
    			.FirstOrDefault()
    			.Value
    			.Split('?');
    
    		String empId = HttpUtility
    			.ParseQueryString(queryString[1])["empid"];
    	}
    }
