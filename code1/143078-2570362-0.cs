    var images = from img in db.Images
						 join imgTags in db.ImageTags on img.idImage equals imgTags.idImage into g
						 from imgTags in g.DefaultIfEmpty()
						 join t in db.Tags on imgTags.idTag equals t.idTag into g1
						 from t in g1.DefaultIfEmpty()
						 where img.OCRData.Contains(searchText.Text)
						 group img by t == null ? "(No Tags)" : t.TagName into aGroup
						 select new
						{
							GroupName = aGroup.Key,
							Items = from x in aGroup
											select new ImageFragment()
											{
												ImageID = x.idImage,
												ScanDate = x.ScanTime
											}
						};
