    public class Program
    {
        static void Main(string[] args)
        {
            string input = "104, 101, 108, 108, 111, 44, 32, 119, 111, 114, 108, 100";
    
            String output = String.Empty;
    
            foreach (var item in input.Split(',').ToArray())
            {
                int unicode = Convert.ToInt32(item);
                var converted = char.ConvertFromUtf32(unicode);
                output += converted;
            }
    
            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
