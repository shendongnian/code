    static class Commander
    {
        private static List<string> Commands;
        public static void AddCommands(string command, int count)
        {
            if (Commands == null) Commands = new List<string>();
            int startValue = Commands.Count + 1;
            int endValue = startValue + count;
            for (int i = startValue; i < endValue; i++)
            {
                Commands.Add(command + i);
            }
        }
        public static void ShowCommands()
        {
            if ((Commands?.Any()).GetValueOrDefault())
            {
                foreach (var command in Commands)
                {
                    Console.WriteLine(command);
                }
            }
            else
            {
                Console.WriteLine("There are no commands available.");
            }
            Console.WriteLine("-------------------\n");
        }
    }
