    var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
    loadedAssemblies
        .SelectMany(x => x.GetReferencedAssemblies())
        .Distinct()
        .Where(y => loadedAssemblies.Any((a) => a.FullName == y.FullName) == false)
        .ToList()
        .ForEach(x => loadedAssemblies.Add(AppDomain.CurrentDomain.Load(x)));
