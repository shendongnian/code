    CreateMap<Vehicle,Motor>()
    .ForMember(g => g.Speed, opt => opt.MapFrom(u=> new Range<SpeedType?>
                    {
                        Min = EnumHelper.GetEnum<SpeedType?>(u.Speed.Min),
                        Max = EnumHelper.GetEnum<SpeedType?>(u.Speed.Max),
                    }))
