    return await _context.Set<PromotionTopicJoin>()
        .Where(pc => pc.PromotionTopicId == TopicId)
        .Select(pc => pc.Promotion)
        .Select(p => new PromotionDTO
        {
            PromotionId = p.PromotionId,
            // I've removed all the other fields
            Topics = p.PromotionTopicJoins.Select(itj => itj.PromotionTopic.Name).ToList()    
        })
        .Where(x => x.Is_Active)
        .OrderByDescending(x => x.Created)
        .ToListAsync(); 
