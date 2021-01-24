    Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Contact, ContactDTO>().ReverseMap();
                    cfg.CreateMap<ContactType, ContactTypeDTO>().ReverseMap();
                    cfg.CreateMap<LinkedContact, ContactDTO>().ConvertUsing(src =>
                    {
                        return Mapper.Map<Contact, ContactDTO>(src.Contact);
                    });
                });
