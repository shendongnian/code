    using System;
    
    public class Publisher
    {
        public event EventHandler Foo;
    
        public void RaiseFoo()
        {
            Console.WriteLine("Raising Foo");
            EventHandler handler = Foo;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
            else
            {
                Console.WriteLine("No handlers");
            }
        }
    }
    
    public class Subscriber
    {
        public void FooHandler(object sender, EventArgs e)
        {
            Console.WriteLine("Subscriber.FooHandler()");
        }
    }
    
    public class Test
    {
        static void Main()
        {
             Publisher publisher = new Publisher();
             Subscriber subscriber = new Subscriber();
             publisher.Foo += subscriber.FooHandler;
             publisher.RaiseFoo();
             publisher.Foo -= subscriber.FooHandler;
             publisher.RaiseFoo();
        }
    }
