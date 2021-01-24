    CreateMap<UserViewModel, UserEntity>()
    	// (1)
    	.ForMember(entity => entity.UserAndTags, opt => opt.MapFrom(model => model.Tags))
    	// (5)
    	.AfterMap((model, entity) =>
    	{
    		foreach (var entityUserAndTag in entity.UserAndTags)
    		{
    			entityUserAndTag.User = entity;
    		}
    	});
    
    // (2)
    CreateMap<TagViewModel, UserAndTagEntity>()
    	// (3)
    	.ForMember(entity => entity.Tag, opt => opt.MapFrom(model => model));
    
    // (4)
    CreateMap<TagViewModel, TagEntity>();
