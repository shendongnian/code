    static void Main()
    {
        Keys keys = Keys.Control | Keys.Shift | Keys.D;
        foreach (Keys key in DecomposeEnum(keys))
        {
            Console.WriteLine(key);
        }
    }
