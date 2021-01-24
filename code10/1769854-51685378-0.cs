    private static bool InterruptableReadLine(out string result)
    {
        var builder = new StringBuilder();
        var info = Console.ReadKey(true);
        while (info.Key != ConsoleKey.Enter && info.Key != ConsoleKey.F10)
        {
            Console.Write(info.KeyChar);
            builder.Append(info.KeyChar);
            info = Console.ReadKey(true);
        }
        Console.WriteLine();
        result = builder.ToString();
        return info.Key == ConsoleKey.F10;
    }
    // reading input, or just waiting for enter in your infinite loop
    string command;
    var interrupted = InterruptableReadLine(out command);
    if (interrupted)
    {
        debug = !debug;
        continue;
    }
    // do stuff with command if necessary
