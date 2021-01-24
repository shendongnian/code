    static void Main(string[] args)
        {
            DisplayString();
            Console.ReadLine();       
        }
     
        public static void DisplayString()
        {
            RunAction( (textToDisplay) =>
            {
                Console.Write(textToDisplay);
            });
        }
        private static void RunAction(Action<string> action)
        {
            action("This Is A Test");
        }
