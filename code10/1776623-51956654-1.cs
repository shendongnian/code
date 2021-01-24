    DateTime? one = new DateTime(2010, 2, 3, 4, 5, 6, DateTimeKind.Utc);
    Dictionary<DateTime?, DateTime?> intern = new Dictionary<DateTime?, DateTime?>();
    intern[one] = one;
    Console.WriteLine(ReferenceEquals(intern[one], intern[one])); <---false
    Console.WriteLine(ReferenceEquals(one, intern[one])); <---false
