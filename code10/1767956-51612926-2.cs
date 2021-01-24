    var roomIds = plan.Rooms.Select(r => r.Id).ToList();
    var maxPerRoom = context.Conferences
    	.Where(conf => roomIds.Contains(conf.RoomId))
    	.GroupBy(conf => conf.RoomId)
    	.Select(g => new
    	{
    		RoomId = g.Key,
    		LastUsedDate = g.Select(conf => conf.EndTime)
    			.DefaultIfEmpty()
    			.Max()
        }
    ).ToList();
    
    var roomData = (
        from rm in plan.Rooms
    	join mx in maxPerRoom on rm.Id equals mx.RoomId
        select new 
        {
            RoomId = rm.Id,
            LastUsedDate = mx.LastUsedDate
        }
    ).ToList();
