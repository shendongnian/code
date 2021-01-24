    // @nuget: HtmlAgilityPack
    using System;
    using HtmlAgilityPack;
    using System.Collections.Generic;
    public class Program
    {
    	public static void Main()
    	{
    		// Load
    		var doc = new HtmlDocument();
    		doc.LoadHtml(@"<td>TheNumber</td><td>ACode</td><td style='width:350px;'>A Special String For The Number</td>");
    		var div = doc.DocumentNode.ChildNodes[2];
    		
    		// Show info
    		System.Console.WriteLine(div.InnerText);
    	}
    }
