    var people = new[]
    {
        new { Firstname = "Bruce", Surname = "Bogtrotter" },
        new { Firstname = "Terry", Surname = "Fields" },
        new { Firstname = "Barry", Surname = "Wordsworth"}
    };
    var guestList = people
                        .OrderBy(p => p.Firstname)
                        .ThenBy(p => p.Surname)
                        .Select(p => $"{p.Firstname} {p.Surname}")
                        .ToString(Environment.NewLine);
