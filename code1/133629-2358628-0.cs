    public class TestThreading
    {
        private object lockThis = new object();
    
        public static void Function() 
        {
            lockThis = new object();
            lock (lockThis)
            {
                // access something   
            }
        }
    }
