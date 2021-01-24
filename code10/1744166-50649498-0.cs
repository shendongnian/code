        void Main()
        {
        	var reatiredListingsList = new List<FeaturedListing>();
        	reatiredListingsList.Add(new FeaturedListing{ Views = 0});
        	reatiredListingsList.Add(new FeaturedListing{ Views = 52});
        	reatiredListingsList.Add(new FeaturedListing{ Views = 05});
        
        	reatiredListingsList = reatiredListingsList.OrderBy(e => e.Views).ToList();
        }
        
        class FeaturedListing
        {
        	public string Title { get; set; }
        	public string Link { get; set; }
        	public string Published { get; set; }
        	public int Views { get; set; }
        	public string Featured { get; set; }
        	public string CategoryName { get; set; }
        }
