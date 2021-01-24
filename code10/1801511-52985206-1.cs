    var query = 
    	from p in source
    	join c in postDisableCoinsQuery on p.Id equals c.PostId into postDisableCoins
        select new PostProject
        {
            PostDisableCoins = postDisableCoins.ToList(),
            WarStartTime = p.WarStartTime,
            WarEndTime = p.WarEndTime,
            WarWinner = p.WarWinner,
            WarDeclarer = post.WarDeclarer
    	};
