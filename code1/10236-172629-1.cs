    Dictionary<int, string> employees = new Dictionary<int, string>
    {
        { 1, "Bob" },
        { 2, "Alice" },
        { 3, "Fred" },
    };
    // standard iteration
    foreach (var pair in employees)
        Console.WriteLine("ID: {0}, Name: {1}", pair.Key, pair.Value);
    // alias Key/Value as ID/Name
    foreach (var emp in employees.Select(p => new { ID = p.Key, Name = p.Value }))
        Console.WriteLine("ID: {0}, Name: {1}", emp.ID, emp.Name);
