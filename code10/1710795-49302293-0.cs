        public static void actionwait(Func<bool> action)
        {
            int seconds = 60;
            for (int i = 0; i < seconds * 5; i++)
            {
                try
                {
                    if (action())
                    {
                        break;
                    }
                }
                catch
                {
                }
                Thread.Sleep(200);
            }
        }
