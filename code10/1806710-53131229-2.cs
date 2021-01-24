    public class Program 
    {
        public static void Main(string[] args)
        {
            var myClass = new MyClass();
            myClass.Run = 0;
            Menu();
        }
    }
    public class MyClass
    {
        public int Run { get; set; }
        public void Menu()
        {
            Run++;
    
            if (Run <= 1) {
                Welcome();
            }
        }
    }
