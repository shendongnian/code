    personFilter = new GenericModelFilter<Person>();
    companyFilter = new GenericModelFilter<Company>();
    addressFilter = new GenericModelFilter<Address>(); //Complex type for Person
    
    ...
    var query = from p in context.Persons.Where(personFilter.GetPredicate())
                join c in context.Companies.Where(companyFilter.GetPredicate()) on p.CompanyID = c.ID
                select p;
