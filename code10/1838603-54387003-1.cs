    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    using HtmlAgilityPack;
    
    public class Program
    {
    	public static void Main()
    	{
    		// Load
    		var doc = new HtmlDocument();
    		doc.LoadHtml(@"<td>TheNumber</td><td>ACode</td><td style='width:350px;'>A Special String For The Number</td>");
    		var div = doc.DocumentNode.ChildNodes.Where(t => t.InnerText == "A Special String For The Number").ToList().FirstOrDefault();
    		
    		// Show info
    		System.Console.WriteLine(div.PreviousSibling.InnerText);		
    		System.Console.WriteLine(div.PreviousSibling.PreviousSibling.InnerText);
    	}
    }
