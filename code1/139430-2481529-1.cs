    foreach (var result in query)
    {
        Console.WriteLine(result.PersonName);
        foreach (var credit in result.Credits)
        {
            string roles = string.Join(",", credit.Roles.ToArray());
            Console.WriteLine("  " + credit.MovieTitle + ": " + roles);
        }
    }
