    Category c = new Category();
    c.Add("books");
    Category a;
    a = c.Find("books");
    a.Add("SF");
    a.Add("drama");
    if (c.Find("SF") != null)
        Console.WriteLine("found SF");
    if (c.Find("other") == null)
        Console.WriteLine("did not find other");
