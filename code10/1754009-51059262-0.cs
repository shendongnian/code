    var ratingsByCategory = from c in categories
                            join p in products on c.CategoryId equals p.CategoryId
                            join r in ratings on p.ProductId equals r.ProductId
                            group new 
                            { 
                                categoryId = c.CategoryId,
                                categoryName = c.Name,
                                rating = r.Rating
                            } by c.CategoryId into g
                            select new
                            {
                                categoryId = g.Key,
                                rating = g.Average(r=>r.rating)
                            };
