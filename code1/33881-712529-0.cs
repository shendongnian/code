    var options = new DataLoadOptions();
    options.AssociateWith<Employee>(e=>
        e.EmployeeStatus.EmployeeStatusLocaliseds
        .Where(esl => esl.LanguageID == 1)
        );
    options.LoadWith<Employee>(e=>e.EmployeeStatus.EmployeeStatusLocaliseds);
    
        using (var context = new MyDbDataContext())
        {
            context.LoadOptions = options;
            var item = (from record in context.Employees
                        select record).Take(1).SingleOrDefault();
        
            Console.WriteLine("{0}: {1}", item.EmployeeName,
                item.EmployeeStatus.EmployeeStatusLocaliseds
                .Single().Description
            );
        }
