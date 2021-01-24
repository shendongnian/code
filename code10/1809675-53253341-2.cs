    var res = 
		(from ugr in userGameRanks
		join r in ranks on ugr.RankId equals r.Id
		join g in games on ugr.GameId equals g.Id
		join u in users on ugr.UserId equals u.Id
		where !ugr.IsDeleted 
			&& u.Id == userId
			&& (
					(ViewerUserID != -1 && ugr.VisibilityId == 1)
				    || ugr.VisibilityId == 2
					|| (ugr.VisibilityId == 0 && userId == ViewerUserID)
				)
		let level =
			(from subUGR in userGameRanks
			join subR in ranks on subUGR.RankId equals subR.Id
			join subG in games on subUGR.GameId equals subG.Id
			join subU in users on subUGR.UserId equals subU.Id
			where !subUGR.IsDeleted 
				&& subU.Id == ViewerUserID
				&& subUGR.GameId == ugr.GameId
			select subR.Level).FirstOrDefault()
			
		select new 
		{
			ugr.RankId, 
			ugr.UserId,
			ugr.GameId,
			ugr.IsDeleted,
			ugr.VisibilityId,
			CanEdit = level > r.Level ? 1 : 0
		});
