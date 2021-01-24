    static void Main(string[] args)
    {
            //var ZipCodes = new List<string>() { "04846", "40569", "76859","54896", "84623" }; // ZipCodes are stored as a string in a List
            var ZipCodes = new List<int>() { 04846, 40569, 76859, 54896, 84623 }; // ZipCodes are stored as an int in a List
            //var userZip = "";
            var userZip = 0;
            do
            {
                Console.WriteLine("Enter a 5 digit zip code to see if it is supported in our area.");
                //userZip = Console.ReadLine(); // Enable to receive userZip as a string
                userZip = int.Parse(Console.ReadLine()); // receive userZip as an int
                if (ZipCodes.Contains(userZip))
                {
                    Console.WriteLine("We support zip code {0}", userZip);
                }
                else
                {
                    Console.WriteLine("We do not support", userZip);
                }
                //} while (userZip != "0");
            } while (userZip != 0);
        }
