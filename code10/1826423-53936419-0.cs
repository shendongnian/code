    var bestPost = (
        from post in dbContext.Posts
        join vote in dbContext.Votes on post.PostId equals vote.PostId into votej
        let voteTotalRating = votej.Sum(pv => pv.Sign)
        join room in dbContext.Rooms on post.RoomId equals room.RoomId
        join game in dbContext.Modules on room.ModuleId equals game.ModuleId
        where room.RoomAccess == RoomAccessType.Open && post.CreateDate > fromDate
        orderby voteTotalRating descending,
            post.CreateDate descending
        select new BestPost {
            UserId = post.UserId,
            ModuleId = game.ModuleId,
            ModuleTitle = game.Title,
            PostId = post.PostId,
            PostText = post.Text,
            PostCommentary = post.Commentary,
            PostCreateDate = post.CreateDate,
            TotalRating = voteTotalRating
        }).FirstOrDefault();
