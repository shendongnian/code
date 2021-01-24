    source.Select(post => new PostProject
                {
                    PostDisableCoins = post.PostDisableCoins
                                        .Select(x => x.OrderBy(x=>x.CoinAmount))
                                        .Select(x => x) 
                                        .Take(3)                                  
                                        .ToList(),
                    WarStartTime = post.WarStartTime,
                    WarEndTime = post.WarEndTime,
                    WarWinner = post.WarWinner,
                    WarDeclarer = post.WarDeclarer
                }); 
