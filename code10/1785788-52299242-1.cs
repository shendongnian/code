    public string Name 
    {
        get; private set;
    }
    public void SetName(string newName)
    {
        if (newName != null && newName.Length > 2)
        {
            System.Console.WriteLine("Bird already has a name");
            Name = newName;
        }
        else if (newName.Length < 3)
        {
            System.Console.WriteLine("New name must be longer than two chars");
        }
        else
        {
            Name = newName;
        }
    }
