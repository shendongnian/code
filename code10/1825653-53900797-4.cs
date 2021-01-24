    public static void ColorFancy(ConsoleColor c1, ConsoleColor c2, Action action)
    {
       Console.ForegroundColor = c1;
       action.Invoke();
       Console.ForegroundColor = c2;
    }
