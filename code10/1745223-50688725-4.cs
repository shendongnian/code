    class Program
    {
        static void Main(string[] args)
        {
            SomethingClass somethingClass = new SomethingClass(new SomeOtherClass());
            somethingClass.doSomething("HEY THERE");
            
        }
    }
    public class SomethingClass
    {
        DoStuff _doStuff;
        public SomethingClass(DoStuff doStuff)
        {
            this._doStuff = doStuff;
        }
        public void doSomething(string stuff)
        {
            _doStuff.PrintText(stuff);
        }
    }
    public class SomeOtherClass : DoStuff
    {
        public void PrintText(string text)
        {
            Console.WriteLine("HEY THERE");
        }
    }
    public interface DoStuff
    {
        void PrintText(string text);
    }
