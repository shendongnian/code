    using System;
    using HtmlAgilityPack;
    public class Program
    {
    	public static void Main()
    	{
    		HtmlWeb web = new HtmlWeb();
    		HtmlDocument html = web.Load("https://en.wikipedia.org/w/index.php?title=Albatross&action=edit");
    
    		var editorContent = html.DocumentNode.SelectSingleNode(@"//textarea[@id='wpTextbox1']").InnerHtml;
    		Console.WriteLine(editorContent);
    	}
    }
