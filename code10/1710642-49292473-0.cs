    using System;
    using System.Reflection;
    internal class Program
    {
        private static void Main()
        {
            var foo = new Foo();
            var fooType = foo.GetType();
            var eventInfo = fooType.GetEvent("Bar");
            var methodInfo = fooType.GetMethod("OnBar", BindingFlags.Static | BindingFlags.Public);
            eventInfo.AddEventHandler(foo, Delegate.CreateDelegate(eventInfo.EventHandlerType, methodInfo));
            foo.RaiseBar();
            Console.ReadKey();
        }
    }
    public class Foo
    {
        public delegate void BarHandler(object sender, BarEventArgs args);
        public event BarHandler Bar;
        public void RaiseBar()
        {
            Bar(this, new BarEventArgs());
        }
        public static void OnBar(object sender, BarEventArgs args)
        {
            Console.WriteLine(args.Guid);
        }
    }
    public class BarEventArgs : EventArgs
    {
        public Guid Guid => Guid.NewGuid();
    }
