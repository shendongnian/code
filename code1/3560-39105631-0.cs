    var s = "ABCDEFG";
    foreach (var item in s.GetEnumeratorWithIndex())
    {
        System.Console.WriteLine("Character: {0}, Position: {1}", item.Value, item.Index);
    }
