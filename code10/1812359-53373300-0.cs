    // @nuget: HtmlAgilityPack
    using System;
    using HtmlAgilityPack;
    
    public class Program
    {
    	public static void Main()
    	{
    		HtmlWeb web = new HtmlWeb();
    		HtmlDocument html = web.Load("https://www.g2crowd.com/products/google-analytics/reviews");
    		var divNodes = html.DocumentNode.SelectNodes("//div[@class='mb-2 border-bottom']");
    		if (divNodes != null)
    		{
    			foreach (var child in divNodes)
    			{
    				var allowedTags = child.SelectNodes(".//h3 | .//h5 | .//p");
    				foreach (var tag in allowedTags)
    					Console.WriteLine(tag.InnerText);
    				Console.WriteLine("======================================");
    			}
    		}
    	}
    }
