		// Bing Image Result for Cat, First Page
		string url = "http://www.bing.com/images/search?q=cat&go=&form=QB&qs=n";
		// For speed of dev, I use a WebClient
		WebClient client = new WebClient();
		string html = client.DownloadString(url);
		// Load the Html into the agility pack
		HtmlDocument doc = new HtmlDocument();
		doc.LoadHtml(html);
		// Now, using LINQ to get all Images
		List<HtmlNode> imageNodes = null;
		imageNodes = (from HtmlNode node in doc.DocumentNode.SelectNodes("//img")
		              where node.Name == "img"
		              && node.Attributes["class"] != null
		              && node.Attributes["class"].Value.StartsWith("img_")
		              select node).ToList();
		foreach(HtmlNode node in imageNodes)
		{
		    Console.WriteLine(node.Attributes["src"].Value);
		}
