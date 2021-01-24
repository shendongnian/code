    using System;
    using System.Linq;
    using Abp.Domain.Entities;
    using AutoMapper;
    
    namespace ProjectName.Persons.Dto {
        public class PersonMapProfile : Profile {
            public PersonMapProfile() {
    
                CreateMap<UpdatePersonDto, Person>();
                CreateMap<UpdatePersonDto, Person>()
                    .ForMember(x => x.Phones, opt => opt.Ignore())
                        .AfterMap((personDto, person) => 
                             AddUpdateOrDelete(personDto, person));
            }
    
            private void AddUpdateOrDelete(UpdatePersonDto dto, Person person) {
                 person.Phones
                .Where(phone =>
                    !dto.Phones
                    .Any(phoneDto => phoneDto.Id == phone.Id)
                )
                .ToList()
                .ForEach(deleted =>
                    person.Phones.Remove(deleted)
                );
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
