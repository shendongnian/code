        void SearchProc()
        {
            bool exitCond = False;
            while (!exitCond)
            {
                //some execution
                //some execution
                //some execution
                //check for the thread-abort flag:
                if (StopTheThread)
                {
                    System.Threading.Thread.Suspend(); //this will suspend the current thread
                }
            }
        }
