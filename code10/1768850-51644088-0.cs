    Regex rgx = new Regex(@"^[^'].*'.*$");
    List<string> list = new List<string>() { "'Chapert 2'", "Chapter's", "chapters'" };
    foreach(var item in list)
    {
        if (rgx.IsMatch(item))
            Console.WriteLine(item);
    }
