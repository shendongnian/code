                static void Main(string[] args)
                {
                    Console.WriteLine("Enter Your Hashsum.");
                    string myhash = Console.ReadLine();
                    var words = myhash.ToCharArray();
                    Console.WriteLine("Modified Hashsum:");
                    foreach (var word in words)
                    {
                        Console.Write($"\"{word}\", ");
                    }
                    Console.ReadKey();
                }
