    var feeds =
        from feed in categoryProducts.AsEnumerable()
    	let MfPN = feed.Field<string>("MfPN")
    	// Get image url if MfPN is not null, else return default image url.
    	let Url = !string.IsNullOrEmpty(MfPN) ? GetImgUrl(MfPN) : “DefaultImage.jpg”
            select new
            {
                Description = feed.Field<string>("description"),
                MfPartNo = MfPN,
                Inventory = feed.Field<Int32>("Inventory"),
    	        ImageUrl = Url
            };
