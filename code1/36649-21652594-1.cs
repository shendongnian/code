    int pairSize = 2;
    var slider = new SlidingWindowCollection<string>(pairSize);
    foreach(var item in items)
    {
        slider.Add(item);
        Console.WriteLine(string.Join(", ", slider));
    }
