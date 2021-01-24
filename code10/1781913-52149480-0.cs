    for (int i = 0; i < botsnumber; i++)
    {
         Bot b = new Bot();
         b.Say();
    }
    class Bot
    {
        public void Say()
        {
            Console.WriteLine("Hello!");
        }
    }
