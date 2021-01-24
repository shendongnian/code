    public class Program
    {
        public static void Main(string[] args)
        {
            string str = @"&1 \&2 \\&3 \\\&4 \\  ";
            Console.WriteLine("Input:  " + str);
            str = Regex.Replace(str, @"\\&", "&");
            str = Regex.Replace(str, @"\\\\", "\\");
            str = Regex.Replace(str, @"&", "§");
            Console.WriteLine("Output: " + str);
        }
    }
