    ILookup<string, Person> personsByType = persons.ToLookup(person => person.Type);
    double getSalary(string type)
    {
         return personsByType[type]
                  .GroupBy(pr => pr.Salary)
                  .OrderByDescending(g => g.Count())
                  .Select(x => x.Key)
                  .FirstOrDefault();
    }
    double salary= getSalary("Manager");
    if (salary == 0)
    {
        salary = getSalary("MiddleManager");
    }
