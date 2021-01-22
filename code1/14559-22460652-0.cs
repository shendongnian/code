    class Program
    {    
        static void Main(string[] args)
            {
                SomePublisher publisher = new SomePublisher();
    
                for (int i = 0; i < 10; i++)
                {
                    SomeSubscriber subscriber = new SomeSubscriber(publisher);
                    subscriber = null;
                }
    
                GC.Collect();
                GC.WaitForPendingFinalizers();
    
                Console.WriteLine(SomeSubscriber.Count.ToString());
    
    
                Console.ReadLine();
            }
        }
    
        public class SomePublisher
        {
            public event EventHandler SomeEvent;
        }
    
        public class SomeSubscriber
        {
            public static int Count;
    
            public SomeSubscriber(SomePublisher publisher)
            {
                publisher.SomeEvent += new EventHandler(publisher_SomeEvent);
            }
    
            ~SomeSubscriber()
            {
                SomeSubscriber.Count++;
            }
    
            private void publisher_SomeEvent(object sender, EventArgs e)
            {
                // TODO: something
                string stub = "";
            }
        }
