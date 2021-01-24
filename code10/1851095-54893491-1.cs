            static void Main(string[] args)
            {
                Console.WriteLine("Enter Your Hashsum.");
                string myhash = Console.ReadLine();
                var charArr = myhash.ToCharArray();
                var words = charArr.Select(s => s.ToString()).ToArray();
                Console.WriteLine("Modified Hashsum:");
                foreach (var word in words)
                {
                    Console.Write($"\"{word}\", ");
                }
                Console.ReadKey();
            }
