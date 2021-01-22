    public class Readtextfile
    {
        public static int Main(string[] args)
        {
            Console.Write("Enter a File Path:");
            string fileName = Console.Readline();
            StreamReader reader = File.OpenText(fileName);
            string input = reader.ReadLine();
            while (input != null)
            {
                Console.WriteLine(input);
                input = reader.ReadLine();
            }
            reader.close;
            return 0;
        }
    }
