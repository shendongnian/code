    class Test 
    {
        Game Game;
        public Test(Game g)
        {
            Game = g;
        }
        public void T()
        {
            Console.WriteLine(Random.Next(0, 10));
            Game.Timers.Start();
        }
    }
