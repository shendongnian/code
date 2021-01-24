    using Abp.Application.Services.Dto;
    using Abp.Application.Services;
    using Abp.Domain.Repositories;
    using Abp.Domain.Uow;
    using Microsoft.EntityFrameworkCore;
    using ProjectName.Companies.Dto;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    namespace ProjectName.Persons {
        public class PersonAppService : AsyncCrudAppService<Person, PersonDto, Guid, GetAllPersonsDto, CreatePersonDto, UpdatePersonDto, EntityDto<Guid>>, IPersonAppService {
            
            private readonly IRepository<Person, Guid> _personRepository;
            private readonly IRepository<PersonPhone, Guid> _personPhoneRepository;
            
            public PersonAppService(
                IRepository<Person, Guid> repository,
                IRepository<PersonPhone, Guid> personPhoneRepository) : base(repository) {
                _personRepository = repository;
                _personPhoneRepository = personPhoneRepository;
            }
            
            [UnitOfWork(IsDisabled = true)]
            public override async Task<PersonDto> Update(UpdatePersonDto input) {
                CheckUpdatePermission();
                using (var uow = UnitOfWorkManager.Begin()) {
                    var person = await _personRepository
                        .GetAllIncluding(
                            c => c.Phones
                        )
                        .FirstOrDefaultAsync(c => c.Id == input.Id);
                    ObjectMapper.Map(input, person);
                    foreach (var phone in person.Phones.ToList()) {
                        if (input.Phones.All(x => x.Id != phone.Id)) {
                            await _personPhonesRepository.DeleteAsync(phone.Id);
                        }
                    }
                    uow.Complete();
                }
                return await Get(input);
            }
        }
    }
