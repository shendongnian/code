            Mapper.Initialize(c =>
            {
                c.CreateMap<UserDTO, UserModelApi>().ConvertUsing(f1 => new UserModelApi()
                {
                    // add the mapping here
                });
            });
            Mapper.AssertConfigurationIsValid();
