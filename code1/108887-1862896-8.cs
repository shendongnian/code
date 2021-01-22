    var questions = from item in feedItems
                    select
                        new Question
                            {
                                Title = item.Title.Text,
                                Author = item.Authors.First().Name,
                                Id = item.Id,
                                Rank = item.ElementExtensions.ReadElementExtensions<int>(
                                    "rank", "http://purl.org/atompub/rank/1.0").FirstOrDefault()
                            };
