    var sites =
        from site in context.Sites
        join photo in context.Photos on site.Id equals photo.SiteId into photos
        from photo in photos.DefaultIfEmpty()
        group photo by site into g
        select new
        {
            Site = g.Key,
            HasPhotoNumber1 = g.Any(x => x.PhotoNumber == 1),
            HasPhotoNumber2 = g.Any(x => x.PhotoNumber == 2),
            HasPhotoNumber3 = g.Any(x => x.PhotoNumber == 3)
        };
