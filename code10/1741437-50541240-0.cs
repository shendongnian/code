    public class Program
    {
        public static void Main(string[] args)
        {
            //Your code goes here
            string mytext ="line1\nline2\nline3";
            string lastLine = mytext.Split('\n').Last();
            Console.WriteLine(lastLine);
        }
    }
