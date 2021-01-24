                Mapper.AssertConfigurationIsValid();
                var destination = Mapper.Map<CaseDto>(_case);
                destination.Customers = Mapper.Map<CustomerEF, CustomersDto>(_customerEf);
                destination.Office = Mapper.Map<OfficeEF, OfficeDto>(_officeEf);
                return destination;
