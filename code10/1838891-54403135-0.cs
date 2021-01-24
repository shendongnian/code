        // Add this mapping, if the name of the property in source and destination type differ.
        CreateMap<Source, Destination>()
            .ForMember(dest => dest.DestinationDictionary, opt => opt.MapFrom(src => src.SourceDictionary));
        // Add this mapping to create an instance of the dictionary, filled by the values from the source dictionary.
        CreateMap</*type of source dictionary*/, Dictionary<myEnum, string>>()
            .ConvertUsing(src =>
            {
                var dict = new Dictionary<myEnum, string>();
                foreach (var item in src)
                {
                    dict.Add(item.Key, myInjectableService.BuildUrl(item.Value));
                }
                return dict;
            }));
