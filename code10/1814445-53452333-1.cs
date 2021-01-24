       class Runner1 : RankedRunner
        {
            public int Rank => 3;
            public void Run()
            {
            }
            public bool Runnable(int input)
            {
                return input > 20;
            }
        }
        class Runner2 : RankedRunner
        {
            public int Rank => 4;
            public void Run()
            {
            }
            public bool Runnable(int input)
            {
                return input > 10;
            }
        }
