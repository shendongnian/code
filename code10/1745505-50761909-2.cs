    using System;
    using System.Linq;
    using AutoMapper;
    
    namespace ProjectName.Persons.Dto {
        public class PersonMapProfile : Profile {
            public PersonMapProfile() {
    
                CreateMap<UpdatePersonDto, Person>();
                CreateMap<UpdatePersonDto, Person>()
                    // can ignore multiple collections/properties
                    // .ForMember(x => x.Addresses, opt => opt.Ignore())
                    // .ForMember(x => x.Emails, opt => opt.Ignore())
                    .ForMember(x => x.Phones, opt => opt.Ignore())
                        .AfterMap((personDto, person) => 
                             AddOrUpdatePhones(personDto, person));
            }
    
            private void AddOrUpdatePhones(UpdatePersonDto dto, Person person) {
                foreach (var phoneDto in dto.Phones) {
                    if (phoneDto.Id == default(Guid)) {
                        person.Phones
                        .Add(Mapper.Map<PersonPhone>(phoneDto));
                    }
                    else {
                        Mapper.Map(phoneDto, 
                            person.Phones.
                            SingleOrDefault(c => c.Id == phoneDto.Id));
                    }
                }
            }
        }
    }
