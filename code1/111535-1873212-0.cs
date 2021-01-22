    public class MyObject
    {
        public void SharedMethod()
        {
            lock (this)
            {
                // Do stuff
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            MyObject o = new MyObject();
    
            lock (o)
            {
                new Thread(() =>
                {
                    // Gets blocked 2s because of external lock
                    o.SharedMethod();
                }).Start();
    
                Thread.Sleep(2000);
            }
        }
    }
