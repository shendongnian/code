    void Main()
    {
    	var reatiredListingsList = new List<FeaturedListing>();
    	reatiredListingsList.Add(new FeaturedListing{ Views = "0 Views"});
    	reatiredListingsList.Add(new FeaturedListing{ Views = "52 Views"});
    	reatiredListingsList.Add(new FeaturedListing{ Views = "5 Views"});
    
    	reatiredListingsList.Sort((x, y) => {
    		var xv = int.Parse(x.Views.Replace(" Views", ""));
    		var yv = int.Parse(y.Views.Replace(" Views", ""));
    		return xv < yv ? -1 : (xv > yv ? 1 : 0);
    	});
    }
    
    class FeaturedListing
    {
    	public string Title { get; set; }
    	public string Link { get; set; }
    	public string Published { get; set; }
    	public string  Views { get; set; }
    	public string Featured { get; set; }
    	public string CategoryName { get; set; }
    }
