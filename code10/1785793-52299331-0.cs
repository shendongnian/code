    public string Name {
        get => name
        set {
             if (value != null && value.Length > 2) {
                 System.Console.WriteLine("Bird already has a name");
                 name = value;
             } else if (value.Length < 3) {
                 System.Console.WriteLine("New name must be longer than two chars");
             } else {
                 name = value;
             }
        }
    }
