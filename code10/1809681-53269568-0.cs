    public class YourResultClass()
    {
        public string GameName { get; set; }
        public string UserName { get; set; }
        public string RankName { get; set; }
        public bool CanEdit { get; set; }
    }
    var targetUserGameRanksQuery = context.Users
        .Where(u => !u.IsDeleted 
            && u.UserId == userId)
        // flatten for use in subsequent join
        .SelectMany(u => u.UserGameRanks);
    IQueryable<YourResultClass> query = null;
    if(viewerUserId.HasValue)
    {
        var viewerGameRanksQuery = context.Users
            .Where(u => !u.IsDeleted 
                && u.UserId == viewerUserId)
            // flatten for use in subsequent join
            .SelectMany(u => u.UserGameRanks);
        var joinQuery = targetUserGameRanksQuery // outer source `o`
            .Join(viewerGameRanksQuery, // inner source `i`
                o => new { o.GameId, o.RankId },
                i => new { i.GameId, i.RankId },
                (o, i) => new
                {
                    GameName = o.Game.Name,
                    TargetUserName = o.Username,
                    TargetRankName = o.Rank.Name,
                    CanEdit = i.Rank.Level > o.Rank.Level,
                    Visibility = o.VisibilityId
                });
        query = joinQuery
            .Where(at =>
                at.Visibility == Visibility.RegisteredUsers
                || (at.Visibility == Visibility.Hidden
                    && userId == viewerUserId.Value)
                || at.Visibility == Visibility.Public )
            .Select(at =>
                new YourResultClass()
                {
                    GameName = at.GameName,
                    UserName = at.UserName,
                    RankName = at.RankName,
                    CanEdit = at.CanEdit,
                });
    }
    else
    {
        query = targetUserGameRanksQuery
            .Where(ugh => ugr.VisibilityId == Visibility.Public)
            .Select(ugh => new YourResultClass()
            {
                GameName = ugr.Game.Name,
                UserName = ugr.Username,
                RankName = ugr.Rank.Name,
                CanEdit = false,
            });
    }
