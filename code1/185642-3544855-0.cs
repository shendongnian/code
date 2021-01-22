    var reviews = db.Reviews
                    .Where(x => x.EntityID == EntityID)
                    .GroupBy(x => x.UserID)
                    .Select(gr => new {
                        UserID = gr.Key,
                        MostRecentReview = gr.OrderByDescending(x => x.DateSubmitted)
                                             .First()
                    });
