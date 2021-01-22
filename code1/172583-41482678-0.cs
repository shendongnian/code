        private void DoSomething(int aHour, int aMinute)
        {
            bool running = true;
            while (running)
            {
                Thread.Sleep(1);
                if (DateTime.Now.Hour == aHour && DateTime.Now.Minute == aMinute)
                {
                    Thread.Sleep(60 * 1000); //Wait a minute to make the if-statement false
                    //Do Stuff
                }
            }
        }
