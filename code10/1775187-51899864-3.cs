    private static void Main()
    {
        var names = new List<string>
        {
            "John Doe",
            "Jane Doe",
            null,
            "",
            "James",
            "John",
            "Harry Potter",
            "George Michael",
            "Billy Bush",
            "Barbara Bush"
        };
        // Output a table of names and user names
        Console.WriteLine("Name".PadRight(20) + "User Name");
        Console.WriteLine("----".PadRight(20) + "---------");
        foreach (var name in names)
        {
            var displayName = name == null
                ? "[NULL]"
                : name.Trim().Length == 0
                    ? "[EMPTY]"
                    : name;
            var userName = GetDefaultUserName(name);
            Console.WriteLine(displayName.PadRight(20) + userName);
        }
        GetKeyFromUser("\nPress any key to exit...");
    }
