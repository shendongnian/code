    using System;
    using HtmlAgilityPack;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		GetLinks();
    	}
    	
    	private static void GetLinks()
            {
                HtmlAgilityPack.HtmlWeb hw = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = hw.Load("https://www.ynet.co.il/home/0,7340,L-8,00.html");
                List<string> htmls = new List<string>();
                foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//img"))
                {
                    string hrefValue = link.GetAttributeValue("src", string.Empty);
                    htmls.Add(hrefValue);
                }
    		foreach(var item in htmls){
    		Console.WriteLine(item);
    		}
    		if(doc.DocumentNode.SelectNodes("//a[@href]")==null){
    		Console.WriteLine("no links");
    		}
            }
    }
