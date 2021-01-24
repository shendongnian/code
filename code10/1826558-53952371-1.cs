	internal class UserDtoProfile : Profile
	{
		public UserDtoProfile()
		{
			CreateMap<UserDto, UserEntity>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
				.ReverseMap();
				
			CreateMap<UserEntity, User>()
			   .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email)).ReverseMap();
		}
	}
