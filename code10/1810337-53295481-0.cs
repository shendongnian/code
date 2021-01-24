    List<string> lst = new List<string>() // or var lst = new List<string>();
    while (!sr.EndOfStream) {
        List.Add(sr.ReadLine());
    }
    for(int i = List.Count - 5; i < List.Count; i++) {
        Console.WriteLine(lst[i]);
    }
