    static void Main()
    {
        string txt = "Hello, world!";
        WriteBlinkingText(txt, 500);
    }
    private static void WriteBlinkingText(string text, int delay)
    {
        bool visible = true;
        while (true)
        {
            Console.Write("\r" + (visible ? text : new String(' ', text.Length)));
            System.Threading.Thread.Sleep(delay);
            visible = !visible;
        }
    }
