    var result = myDbContext.Materials
       .Where(material => ...)            // only if you don't want all Materials
       .Select(material => new            // from every Material make one new object
       {                                  // containing the following properties
           Title = material.Title,
           Content = material.Content,
           // if you want any information of the likes of this material, use property Likes
           LikeCount = material.Likes
               .Where(like => like.IsLiked)  // optional, only if you don't want all likes
               .Count(),
           NrOfVisitors = material.Visitors
               .Where(visitor => ...)        // only if you don't want all visitors
               .Count(),
       });
