	var results = News.Join(Categories, 		// Join News and Categories
							a => a.CatergoryId, 
							b => b.Id, 
							(a,b) => new { News = a, Category = b}
						)  
		.GroupBy(c => c.Category) // "partition by categoryId"
		.SelectMany(g => g.OrderBy(gd => gd.News.CreationDate)   // "order by Date"
							.Take(5)	// RankNo <= 5
							.Select(gdd => new {			// results
									Id = gdd.News.Id, 
									Date = gdd.News.Date, 
									CategoryTitle = gdd.Category.Title,
									Title = gdd.News.Title,
									Description = gdd.News.Description, 
									Image = gdd.News.Image
								})
					);
