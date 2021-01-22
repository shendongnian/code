    foreach (var h in AssemblyHelper.GetImplementors<IProjectHours>()) {
       h.SetHours(projects);
    }
    Console.WriteLine(projects.Sum(p => p.NumberOfHours));
    // Non-LINQ equivalent
    int totalNumberHours = 0;
    foreach (Project p in projects) {
       totalNumberOfHours += p.NumberOfHours;
    }
    Console.WriteLine(totalNumberOfHours);
