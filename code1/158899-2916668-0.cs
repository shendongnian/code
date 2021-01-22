    public override string ToString()
    {
        Console.WriteLine(
           string.Format("some_object.name = {0}, formatter.Format(some_object.name) = {1}",
              some_object.name,
              formatter.Format(some_object.name));
        return formatter.Format(some_object.name);
    }
