    static void Main(string[] args)
    {
        ConsoleSpinner spin = new ConsoleSpinner();
        Console.Write("Working....");
        while (true) 
        {
            spin.Turn();
        }
    }
    public class ConsoleSpinner
    {
        int counter;
        public ConsoleSpiner()
        {
            counter = 0;
        }
        public void Turn()
        {
            counter++;        
            switch (counter % 4)
            {
                case 0: Console.Write("/"); break;
                case 1: Console.Write("-"); break;
                case 2: Console.Write("\\"); break;
                case 3: Console.Write("|"); break;
            }
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
    }
