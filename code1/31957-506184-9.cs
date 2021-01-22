    using System;
    
    public class Publisher
    {
        ~Publisher()
        {
            Console.WriteLine("~Publisher");
            Console.WriteLine("Foo==null ? {0}", Foo == null);
        }
    
        public event EventHandler Foo;
    }
    
    public class Subscriber
    {
        ~Subscriber()
        {
            Console.WriteLine("~Subscriber");
        }
    
        public void FooHandler(object sender, EventArgs e) {}
    }
    
    public class Test
    {
        static void Main()
        {
             Publisher publisher = new Publisher();
             Subscriber subscriber = new Subscriber();
             publisher.Foo += subscriber.FooHandler;
    
             Console.WriteLine("No more refs to publisher, "
                 + "but subscriber is alive");
             GC.Collect();
             GC.WaitForPendingFinalizers();         
    
             Console.WriteLine("End of Main method. Subscriber is about to "
                 + "become eligible for collection");
             GC.KeepAlive(subscriber);
        }
    }
