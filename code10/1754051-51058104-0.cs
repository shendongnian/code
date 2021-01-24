    private static void Outputter(IUser user)
    {
        foreach (var prop in typeof(IUser).GetProperties())
        {
            Console.WriteLine($"{prop.Name}: {prop.GetValue(user)}");
        }
    }
