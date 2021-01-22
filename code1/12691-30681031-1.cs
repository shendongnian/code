        static void CheckStackDepth()
        {
            if (new StackTrace().FrameCount > 10) // some arbitrary limit
            {
                throw new StackOverflowException("Bad thread.");
            }
        }
        static int Recur()
        {
            CheckStackDepth();
            int variable = 1;
            return variable + Recur();
        }
        static void Main(string[] args)
        {
            try
            {
                int depth = 1 + Recur();
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine("We've been a {0}", e.ExceptionState);
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
