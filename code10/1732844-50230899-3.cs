        public delegate void ExceutionHandler(int value);
        public class UpdateDataProgress
        {
            public event ExceutionHandler ExecutionDone;
            public void ExecuteFucntion()
            {
                for (int i = 0; i < 100; i++)
                {
                    //perform your logic
                    //raise an event which will have current i 
                    //      to indicate current state of execution
                    //      use this event to update progress bar 
                    if (ExecutionDone != null)
                        ExecutionDone(i);
                }
            }
        }
