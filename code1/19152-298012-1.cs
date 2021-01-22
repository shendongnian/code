    string foo = null;
    foo.Spooky();
    ...
    public static void Spooky(this string bar) {
        Console.WriteLine("boo!");
    }
