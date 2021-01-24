    in your case it might be:
    
    source.Select(post => new PostProject
                {
                    PostDisableCoins = post.PostDisableCoins
                                        .Select(x => x.OrderBy(x=>x.CoinAmount).Take(3))
                                        .Select(x => x)                                   
                                        .ToList(),
                    WarStartTime = post.WarStartTime,
                    WarEndTime = post.WarEndTime,
                    WarWinner = post.WarWinner,
                    WarDeclarer = post.WarDeclarer
                }); 
