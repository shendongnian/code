    using System.Text;
    
    internal class Program
    {
        internal static void Main(string[] args)
        {
            StringBuilder test = new StringBuilder("ABCDEFGHIJKLMNOP", 16);
            test.Append("ABC");
    
            StringBuilder test2 = new StringBuilder("ABCDEFGHIJKLMNOP", 32);
            test2.Append("ABC");
        }
    }
