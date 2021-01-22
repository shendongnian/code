    static void Main(string[] args)
    {
        var spin = new ConsoleSpinner();
        Console.Write("Working....");
        while (true) 
        {
            spin.Turn();
        }
    }
    public class ConsoleSpinner
    {
        int counter;
        public void Turn()
        {
            counter++;        
            switch (counter % 4)
            {
                case 0: Console.Write("/"); counter = 0; break;
                case 1: Console.Write("-"); break;
                case 2: Console.Write("\\"); break;
                case 3: Console.Write("|"); break;
            }
            Thread.Sleep(100);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
    }
