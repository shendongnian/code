    class Program
    {
        delegate int del(int i);
        static void Main(string[] args)
        {            
            del myDelegate = x => x * x;
            int j = myDelegate(5); //j = 25
        }
    }
