    namespace Hash_Checker
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Enter Your Hashsum.");
                string myString = Console.ReadLine();
                //turn each character into a string that looks like "<character here>"
                List<string> characters = myString.Select(x => string.Format("\"{0}\"", x.ToString())).ToList();
                //place comma in between each string containing "<character here>"
                var formattedString = string.Join(",", characters);
                System.Console.Write(formattedString);
                Console.ReadKey();
            }
        }
    }
