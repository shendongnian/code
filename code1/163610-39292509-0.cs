    var stringToMatch = "test";
    var temp = new List<string>();
    var x = new ConcurrentBag<string>();
    for (int i = 0; i < 10; i++)
    {
        x.Add(string.Format("adding{0}", i));
    }
    string y;
    while (!x.IsEmpty)
    {
        x.TryTake(out y);
        if(string.Equals(y, stringToMatch, StringComparison.CurrentCultureIgnoreCase))
        {
             break;
        }
        temp.Add(y);
    }
    foreach (var item in temp)
    {
         x.Add(item);
    }
