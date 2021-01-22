    class ConsoleSpinner
    {
        int counter;
        int spinpos;
        string[] sequence;
        public ConsoleSpinner()
        {
            counter = 0;
            spinpos = 0;
            sequence = new string[]{"/","-","\\","|"};
        }
        public void Turn()
        {
            counter++;
            // so we can spin forever!
            if (counter >= sequence.Length)
                counter = 0;
            spinpos = counter % sequence.Length;
            Console.Write(sequence[spinpos]);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
    }
