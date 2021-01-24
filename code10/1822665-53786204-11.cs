    public static IEnumerable<Errors> NotAssignedIn(
        this IEnumerable<Errors> errors, 
        IEnumerable<Tasks> tasks)
    {
        var assigned = new HashSet<(int Id, int Occurrence)>();
        foreach (var task in tasks)
        {
            assigned.Add((task.Id, task.Occurrence));
        }
        foreach (var error in errors)
        {
            if (assigned.Contains((error.Id, error.Occurrence)) == false)
            {
                yield return error;
            }            
        }
    }
