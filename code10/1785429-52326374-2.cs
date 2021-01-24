    using System;
    using System.Net;	
    using System.Xml;
    using AngleSharp.Parser.Html;
    public class Program
    {
    	public static void Main()
    	{
    		string xmlStringWorking = "<xml>&ast; &dollar; &copy; &uml; &Agrave; &yen; &sect;</xml>";
    		
    		var parser = new HtmlParser();
    		
    		var document = parser.Parse(xmlStringWorking);
    		
    		XmlDocument doc = new XmlDocument();
    		
    		doc.LoadXml(document.DocumentElement.GetElementsByTagName(@"body").First().InnerHtml.Replace("&nbsp;"," "));
    		
    		Console.WriteLine(document.DocumentElement.GetElementsByTagName(@"body").First().InnerHtml.Replace("&nbsp;"," "));
    	}
    }
  
