        private void SomeMethod()
        {
            for (int i = 0; i <= 100000; i++)
            {
                Console.WriteLine(i);
                if (LoopIncrement != null)
                {
                    CancelEventArgs args = new CancelEventArgs();
                    LoopIncrement(null, args);
                    if (args.Cancel)
                    {
                        break;
                    }
                }
            }
