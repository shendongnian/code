    namespace Hash_Checker
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Enter Your Hashsum.");
                var myString = Console.ReadLine();
                //select each character from the string and turn 
                //each into a string that looks like "<character here>"
                var characters = myString.Select(x => string.Format("\"{0}\"", x));
                //place comma in between each string containing "<character here>"
                var formattedString = string.Join(",", characters);
                System.Console.Write(formattedString);
                Console.ReadKey();
            }
        }
    }
