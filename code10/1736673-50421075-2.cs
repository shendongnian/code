    CreateMap<Community, CommunityModel>()
        .ForMember(dest=>dest.Users, opt=> opt.Ignore())
        .AfterMap( ( src, dest, rc ) =>
        {
            foreach( var srcUser in src.Users )
            {
                dest.Users.Add(rc.Mapper.Map<CommunityUserModel>(srcUser));
            }
        } );
