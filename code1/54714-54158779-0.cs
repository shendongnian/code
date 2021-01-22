cs
class Program
{
    static void Main(string[] args)
    {
        // Reader
        new Thread(() =>
        {
            string line;
            while ((line = Read()) != null)
            {
                //...
            }
            Environment.Exit(0);
        }).Start();
        // Writer
        new Thread(() =>
        {
            while (true)
            {
                Thread.Sleep(1000);
                Log("----------");
            }
        }).Start();
    }
    static int lastWriteCursorTop = 0;
    static void Log(string message)
    {
        int messageLines = message.Length / Console.BufferWidth + 1;
        int inputBufferLines = Console.CursorTop - lastWriteCursorTop + 1;
        Console.MoveBufferArea(sourceLeft: 0, sourceTop: lastWriteCursorTop,
                               targetLeft: 0, targetTop: lastWriteCursorTop + messageLines,
                               sourceWidth: Console.BufferWidth, sourceHeight: inputBufferLines);
        int cursorLeft = Console.CursorLeft;
        Console.CursorLeft = 0;
        Console.CursorTop -= inputBufferLines - 1;
        Console.WriteLine(message);
        lastWriteCursorTop = Console.CursorTop;
        Console.CursorLeft = cursorLeft;
        Console.CursorTop += inputBufferLines - 1;
    }
    static string Read()
    {
        Console.Write(">");
        string line = Console.ReadLine();
        lastWriteCursorTop = Console.CursorTop;
        return line;
    }
}
