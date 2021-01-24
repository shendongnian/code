    var sites =
        from site in context.Sites
        join photo in context.Photos on site.Id equals photo.SiteId into photos
        from photo in photos.DefaultIfEmpty()
        group photo by site into g
        select new
        {
            site = g.Key,
            hasPhotoNumber1 = g.Any(x => x.PhotoNumber == 1),
            hasPhotoNumber2 = g.Any(x => x.PhotoNumber == 2),
            hasPhotoNumber3 = g.Any(x => x.PhotoNumber == 3)
        };
