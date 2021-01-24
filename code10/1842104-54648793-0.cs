var tagCountPerDay = session
				.Query<TagByDayIndex, Toss_TagPerDay>()
				.Where(i => i.CreatedOn >= DateTime.Now.AddDays(-30))
				.ToList();
Then you can the the client side grouping by Tag:
var mostUsedTags = tagCountPerDay.GroupBy(x => x.Tag)
                        .Select(t => new BestTagsResult()
                        {
                            CountLastMonth = t.Count(),
                            Tag = t.Key
                        })
                        .OrderByDescending(g => g.CountLastMonth)
                        .ToList();
