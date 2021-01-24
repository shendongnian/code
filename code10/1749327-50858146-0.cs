        var objects = new[]{
                        new MyObject{Description = "Foo Bar"},
                        new MyObject{Description = "Foo Boo"},
                        new MyObject{Description = "Foo Bee"},
                        new MyObject{Description = "Bar Bee"},
                        new MyObject{Description = "Boo Bee"},
                    };
                    var keywords = new[] { "Foo", "Bar" };
                    var results = objects
                        .GroupBy(x => keywords.Where(
                                              keyword => x.Description.Contains(keyword) 
                                              ).Count()
                        )
                        .Where(x => x.Key > 0) // discard no matches
    //                    .OrderByDescending(x => x.Count()) // order by mathing objects count
                        .OrderByDescending(x => x.Key)
    //                   .ToDictionary(x => x.Key, x => x.ToArray())
                         .Select(x => new {Count = x.Key, Objects = x.ToArray()}).ToList(); // or create anonymous type
                        ;
