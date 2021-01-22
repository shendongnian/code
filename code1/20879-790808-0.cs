    static void Main(string[] args)
    {
    	var feedUrl = "http://blog.stackoverflow.com/index.php?feed=podcast";
    
    	using (var feedReader = XmlReader.Create(feedUrl))
    	{
    		var feedContent = SyndicationFeed.Load(feedReader);
    
    		if (null == feedContent) return;
    
    		foreach (var item in feedContent.Items)
    		{
    			Debug.WriteLine("Item Title: " + item.Title.Text);
    
    			Debug.WriteLine("Item Links");
    			foreach (var link in item.Links)
    			{
    				Debug.WriteLine("Link Title: " + link.Title);
    				Debug.WriteLine("URI: " + link.Uri);
    				Debug.WriteLine("RelationshipType: " + link.RelationshipType);
    				Debug.WriteLine("MediaType: " + link.MediaType);
    				Debug.WriteLine("Length: " + link.Length);
    			}
    		}
    	}
    }
		
