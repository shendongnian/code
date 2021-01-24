    var myList = new List<string>
                      {
                         "one",
                         "two",
                         "three"
                      };
    var input = "One times two plus one equals three";
    var inputList = input.Split(new []{' '},StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower());
    var result = inputList.Where(x => myList.Contains(x.ToLower()))
                .ToList();
    Console.WriteLine(string.Join(", ", result));
    Console.WriteLine(result.Count());
