    public class BaseContainer<T> : IEnumerable<T>
    {
        public virtual void DoStuff<TOther>(TOther item) where TOther : T
        {
            Console.WriteLine(item);
        }
        public IEnumerator<T> GetEnumerator() {
            return (IEnumerator<T>) GetEnumerator(); }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw new NotImplementedException(); }
    }
    public class Container<T> : BaseContainer<T>
    {
        public void DoStuff(IEnumerable<T> collection)
        {
            foreach(var item in collection)
                Console.WriteLine(item);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Container<string> c = new Container<string>();
            
            var list = new List<string>();
            list.Add("hello");
            list.Add("world");
            c.DoStuff("Hello World");
            c.DoStuff(list);
            BaseContainer<string> b = c;
            b.DoStuff("Hello World");
        }
    }
