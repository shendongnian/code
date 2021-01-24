    CreateMap<EventAttendee, AttendeeDto>()
       .ForMember(d => d.Id, o => o.MapFrom(s => s.AppUserId))
       .ForMember(d => d.UserName, o => o.MapFrom(s => s.AppUser.UserName))
       .ForMember(d => d.DateJoined, o => o.MapFrom(s => s.DateJoined));
    CreateMap<Event, EventToReturnDto>();
