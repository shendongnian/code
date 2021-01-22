    List<Predicate<Issue>> conditions = new List<Predicate<Issue>>();
    if (departmentToShow != "All")
        conditions.Add(i => i.IssDepartment == departmentToShow);
    if (someOtherThing)
        conditions.Add(anotherPredicate);
    // etc. snip adding conditions
    var issues = from i in issues
                 where conditions.All(c => c(i))
                 orderby i.IssDueDate, i.IssUrgency;
