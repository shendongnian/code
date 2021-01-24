    List<int> list = new List<int>();
    for (int i = 0; i < x; i++)
    {
        var vec = vector.Skip(index).Take(width);
        list.AddRange(vec);
        index = index + width;
    }
    string toDisplay = string.Join(Environment.NewLine, lines);
