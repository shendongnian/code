    public interface ICanAdd
    {
        int Add(int x, int y);
    }
    
    // Note that MyAdder does NOT implement ICanAdd, 
    // but it does define an Add method like the one in ICanAdd:
    public class MyAdder
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
    }
    
    public class Program
    {
        void Main()
        {
            MyAdder myAdder = new MyAdder();
    
            // Even though ICanAdd is not implemented by MyAdder, 
            // we can duck cast it because it implements all the members:
            ICanAdd adder = DuckTyping.Cast<ICanAdd>(myAdder);
    
            // Now we can call adder as you would any ICanAdd object.
            // Transparently, this call is being forwarded to myAdder.
            int sum = adder.Add(2, 2);
        }
    }
