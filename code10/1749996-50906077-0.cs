    interface IMessage<out T> where T : IFoo { }
    class Message<T> : IMessage<T> where T:IFoo { }
    interface IFoo { }
    class Foo : IFoo { }
    class Bar : IFoo { }
    class Program
    {
        static void Ex1()
        {
            var o1 = Observable.Interval(TimeSpan.FromMilliseconds(200)).Select(x => (IMessage<IFoo>)new Message<Foo>());
            var o2 = Observable.Interval(TimeSpan.FromMilliseconds(200)).Select(x => (IMessage<IFoo>)new Message<Bar>());
            o1.Merge(o2).Subscribe(Console.WriteLine);
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Ex1();
        }
    }
