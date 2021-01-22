		var activeProduct =(from product in Master.DataContext.ProductSet
							where product.Active == true
							   && product.ShowOnWebSite == true
							   && product.AvailableDate <= DateTime.Today
							   && ( product.DiscontinuationDate == null || product.DiscontinuationDate >= DateTime.Today )
							select product.ManufacturerID ).Distinct();
		var artists = from artist in Master.DataContext.ContactSet
							select artist;
		List<Evolution.API.Contact> activeArtists = new List<Evolution.API.Contact>();
		foreach (var artist in artists)
		{
			foreach(var product in activeProduct)
			{
				if (product.HasValue && product.Value == artist.ID)
					activeArtists.Add(artist);
			}
		}
		NumberOfArtists = activeArtists.Count();
		artistsRepeater.DataSource = activeArtists;
		artistsRepeater.DataBind();
