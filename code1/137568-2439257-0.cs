    var issues = db.Issues;
    if (departmentToShow != "All")
    {
        issues = issues.Where(i => i.IssDepartment == departmentToShow);
    }
    issues = issues.OrderBy(i => i.IssDueDate).ThenBy(i => i.IssUrgency);
