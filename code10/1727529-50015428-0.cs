		// Effectively infinite pages of images query
		IObservable<List<TumblrFile>> observableOfListsOfImages=
			from index in Observable.Range(0, int.MaxValue)
			from document in Observable.Start(() => XDocument.Load(GetApiLink(pageAddress, index * 50, true)))
			from images in Observable.Start(() => XmlUtilities.ExtractImagesFromDocument(document, saveLocation))
			select images;
		
		// Stop query when empty list returned
		// and wait for results
		TumblrFile[] arrayOfImages =
			observableOfListsOfImages
				.TakeWhile(x => x.Any())
				.SelectMany(x => x)
				.ToArray()
				.Wait();
		
		// Remove any duplicates based on `.Address` property
		List<TumblrFile> listOfImages =
			arrayOfImages
				.GroupBy(x => x.Address)
				.SelectMany(x => x.Take(1))
				.ToList();
				
		return listOfImages;
