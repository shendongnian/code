    var set = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
             {
                "one",
                "two",
                "three"
             };
    var input = "One times two plus one equals three";
    var inputList = input.Split(new []{' '},StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToLower());
    var result = inputList.Where(x => set.Contains(x)).ToList();
    Console.WriteLine(string.Join(", ", result));
    Console.WriteLine(result.Count());
