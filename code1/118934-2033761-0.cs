    var tagList = existingList.GroupBy( t => new { t.TagID, t.TagName } )
                              .Select( g => new Tag {
                                             TagID = g.Key.TagID,
                                             TagName = g.Key.TagName,
                                             TagCount = g.Sum( t => t.TagCount )
                              })
                              .ToList();
