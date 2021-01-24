    var sites = (from site in context.Sites
                 join p in context.Photos on site.SiteID equals p.SiteId into pj
                 select new {
                     Site = site,
                     Cam1 = pj.Any(p => p.PhotoNumber == 1),
                     Cam2 = pj.Any(p => p.PhotoNumber == 2),
                     Cam3 = pj.Any(p => p.PhotoNumber == 3)
                 }).ToList();
