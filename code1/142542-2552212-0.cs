    public static class MyClass
    {
        private static Semaphore sem = new Semaphore(5, 5);
    
        public static void SendMessage()
        {
            sem.WaitOne();
    
            try
            {
            }
            finally
            {
                sem.Release(1);
            }
        }
    }
