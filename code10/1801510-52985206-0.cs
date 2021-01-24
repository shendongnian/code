    var postDisableCoinsQuery = source.SelectMany(p =>
        db.Set<PostDisableCoin>()
            .Where(c => c.PostId == p.Id)
            .OrderByDescending(c => c.CoinAmount)
            .Take(3)
    );
   
