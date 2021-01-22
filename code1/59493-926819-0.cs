    List<string> list = new List<string>();
    list.Add("one");
    list.Add("two");
    list.Add("three");
    List<string> copyList = list.FindAll(
        s => s.Length >= 5
    );
    copyList.ForEach(s => Console.WriteLine(s));
