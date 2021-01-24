    <pre><code>static void Main(string[] args)
    {
        int i = 0;
        while (true)
        {
            var key = ReadKey();
            if (key == ConsoleKey.UpArrow)
            {
                Console.WriteLine(++i);
            }
        }
    }</pre></code>
 
