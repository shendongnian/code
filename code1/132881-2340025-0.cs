    var groups = presidents.GroupBy(prez => prez.Length <= 5);
    foreach(var group in groups)
    {
        // This time the key will be true or false
        Console.WriteLine("******" + group.Key + "******" );
        foreach(String name in group)
        {
            Console.WriteLine(name);
        }
    }
