    public static int AskInt(string question)
    {
            int questionId;
            while (true)
            {
                Console.Write(question);
                string input = Console.ReadLine();
                if (int.TryParse(input , out questionId))
                {
                     break;
                }
            }
     }
