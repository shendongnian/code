    public class ConsoleSpinner
        {
            int counter;
            public void Turn()
            {
                counter++;
                switch (counter % 4)
                {
                    case 0: Console.Write("."); counter = 0; break;
                    case 1: Console.Write(".."); break;
                    case 2: Console.Write("..."); break;
                    case 3: Console.Write("...."); break;
                    case 4: Console.Write("\r"); break;
                }
                Thread.Sleep(100);
                Console.SetCursorPosition(23, Console.CursorTop);
            }
        }
