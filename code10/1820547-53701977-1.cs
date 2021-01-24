    var result = ctx.materials.Select(x => 
         new SomeClass{
              Material = x,
              Visitors = x.Visitors.Where(v => v.ReadNow).Count(),
              Likes = x.Likes.Where(y => y.IsLiked).Count(),
              Liked = x.Likes.Where(z => z.IsLiked && z.UserID == myID).Count()
         }).ToList();
