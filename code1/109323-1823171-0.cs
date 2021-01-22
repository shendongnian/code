    Dictionary<string, Action<string>> actions =
        new Dictionary<string, Action<string>>()
        {
            { "Hello", HandleHello },
            { "Goodbye", HandleGoodbye }
        };
    private static void HandleHello(string s) { ... }
    private static void HandleGoodbye(string s) { ... }
    ...
    actions[s](s);
