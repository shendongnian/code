    List<MyStruct> obList2 = new List<MyStruct>();
    obList2.Add(new MyStruct("ABC"));
    obList2.Add(new MyStruct("DEF"));
    obList2[1].SetName("WTH");
    foreach (MyStruct s in obList2) // => "ABC", "DEF"
    {
        Console.WriteLine(s.Name);
    }
