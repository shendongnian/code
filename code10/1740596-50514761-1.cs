    public class FClass
    {
        public delegate string Show(int n);
        public void ShowDelegate(Show SD)
        {
            Console.WriteLine(SD(1)); // <-- Show delegate text
        }
    }
    public class SClass
    {
        static string ReturnString(int n)
        {
            return n.ToString();
        }
        static void Main(string[] args)
        {
            FClass fclass = new FClass();
            FClass.Show show = new FClass.Show(ReturnString);
            fclass.ShowDelegate(show);
            Console.ReadKey();
        }
    }
