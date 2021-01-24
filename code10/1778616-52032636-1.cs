    Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Contact, ContactDTO>().ReverseMap();
                    cfg.CreateMap<ContactType, ContactTypeDTO>().ReverseMap();
                    cfg.CreateMap<LinkedContact, ContactDTO>().ConvertUsing(src =>
                    {
                        var contact = Mapper.Map<Contact, ContactDTO>(src.Contact);
                        contact.ContactType = Mapper.Map<ContactType, ContactTypeDTO>(src.ContactType);
                        return contact;
                    });
                });
