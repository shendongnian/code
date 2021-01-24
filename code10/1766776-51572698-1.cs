    public abstract class DoSth
    {
        public void DoSomething()
        {
            Console.WriteLine("I'm doing something");
            this.DoSomethingBigger();
        }
        protected abstract void DoSomethingBigger();
    }
    
    public class Writer : DoSth
    {
        protected virtual override void DoSomethingBigger()
        {
            Console.WriteLine("I'm writting");
        }
    }
    
    public class BookWriter : Writer
    {
        protected override void DoSomethingBigger()
        {
            Console.WriteLine("I'm writting a book");
        }
    }
