    public IQueryable<IPerson> getPersons() {
        // gives Types in Union or Concat have different members assigned error
        var people = from p in db.Persons select p;
        return (from s in people
                        where s.TypeId == (int)PersonType.Student
                        select new Student
                        {
                            Id = s.Id,
                            Age = s.Age.GetValueOrDefault(0),
                            Name = s.Name,
                            Major = s.Student.Major ?? "None",
                            CreditHours = s.Student.CreditHours.GetValueOrDefault(0),
                            PersonType = (PersonType)s.TypeId
                        }).Cast<IPerson>().Union((from e in people
                            where e.TypeId == (int)PersonType.Employee
                            select new Employee
                            {
                                Id = e.Id,
                                Age = e.Age.GetValueOrDefault(0),
                                Name = e.Name,
                                PersonType = (PersonType)e.TypeId,
                                Salary = e.Employee.Salary.GetValueOrDefault(0)
                            }).Cast<IPerson>());
    }
