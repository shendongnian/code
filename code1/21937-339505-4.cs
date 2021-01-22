    using (StreamReader sr = new StreamReader("c:\\test.file"))
    {
        var qry = from l in CreateEnumerable(sr).Skip(1)
                  where l[3].Contains("something")
                  select new { Field1 = l[0], Field2 = l[1] };
        foreach (var item in qry)
        {
            Console.WriteLine(item.Field1 + " , " + item.Field2);
        }
    }
    Console.ReadLine();
