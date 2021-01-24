    using System;
    using System.Collections.Specialized;
    using System.Reflection;
    
    class Program
    {
        static void Main()
        {
            Type AType = typeof(Foo);
            var ObjectOfAType = new Foo();
    
            Delegate myhandler = (NotifyCollectionChangedEventHandler)SomeHandler;
            EventInfo info = AType.GetEvent("CollectionChanged");
            info.AddEventHandler(ObjectOfAType, myhandler);
    
            // prove it works
            ObjectOfAType.OnCollectionChanged();
        }
    
        private static void SomeHandler(object sender, NotifyCollectionChangedEventArgs e)
            => Console.WriteLine("Handler invoked");
    }
    public class Foo
    {
        public void OnCollectionChanged() => CollectionChanged?.Invoke(this, null);
        public event NotifyCollectionChangedEventHandler CollectionChanged;
    }
