    static void WriteStudents(string first = null, string second = null)
    {
        var query = Students.Where(s => string.IsNullOrWhiteSpace(first)
                                     && string.IsNullOrWhiteSpace(second)
                                     || s.Name == first || s.Name == second)
                            .Select(s => s.Id); // used to print the Id
        
        Console.WriteLine(string.Join(",", query));
    }
