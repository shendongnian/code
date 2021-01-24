    namespace Hash_Checker
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Enter Your Hashsum.");
                string myhash = Console.ReadLine();
                //replace all spaces 
                string words = myhash.Replace(" ", "");
                Console.WriteLine("Modified Hashsum:");
                StringBuilder sb = new StringBuilder();
                //loop thru chars
                foreach (var c in words)
                {
                    sb.Append($"\"{c}\", ");
                }
                //trim the comma and space at the end of string and write it to console
                Console.WriteLine(sb.ToString().TrimEnd(new char[] { ',', ' ' }));
                Console.ReadKey();
            }
        }
    }
