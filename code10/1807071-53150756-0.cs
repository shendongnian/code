    class Program
    {
        static void Main(string[] args)
        {
            var m = typeof(Program).GetMethod("PrintValue");
            var i  = new Program();
            m.Invoke(i, BindingFlags.Default, null, new object[] {42}, CultureInfo.CurrentCulture);
        }
        public void PrintValue(int i)
        {
            Console.WriteLine(i);
        }
    }
