    double? getSalary(string type)
    {
       IEnumerable<Person> selectedPeople = personsByType[type];
  
       return selectedPeople.Any() ? selectedPeople
                                      .GroupBy(pr => pr.Salary)
                                      .OrderByDescending(g => g.Count())
                                      .Select(x => x.Key)
                                      .First()
                                   : null;
    }
    double? salary= getSalary("Manager");
    if (!salary.HasValue)
    {
        salary = getSalary("MiddleManager");
    }
