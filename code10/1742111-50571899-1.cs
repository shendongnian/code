    config.AddMemberConfiguration().AddMember<CustomMapMember>(m =>
    	// Configure the custom mappings here
    	m.Add(typeof(ViewModel), typeof(ObjectReturnByLinqQuery), nameof(ObjectReturnByLinqQuery.classOne))
    );
    
    config.CreateMap<ObjectReturnByLinqQuery, ViewModel>()
    	.ForMember(ViewModel => ViewModel.EmailClasseTwo, ModelDB => ModelDB.MapFrom(src => src.classTwo.Email))
    	.ForMember(ViewModel => ViewModel.EmailClassThree, ModelDB => ModelDB.MapFrom(src => src.classThree.Email));
