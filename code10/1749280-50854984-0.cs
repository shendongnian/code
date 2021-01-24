    namespace ConsoleTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var lst1 = new List<Sig>()
                {
                    new Sig
                    {
                        Key=501,
                        Value="value 501"
                    },
                    new Sig
                    {
                        Key=501,
                        Value="another value 501"
                    }
                };
    
                var lst2 = new List<Sig>()
                {
                    new Sig
                    {
                        Key=505,
                        Value="value 505"
                    },
                    new Sig
                    {
                        Key=505,
                        Value="another value 505"
                    }
                };
    
                var lst3 = new List<Sig>()
                {
                    new Sig
                    {
                        Key=502,
                        Value="value 502"
                    },
                    new Sig
                    {
                        Key=502,
                        Value="another value 502"
                    }
                };
    
                var allList = new List<List<Sig>>()
                {
                    lst1,lst2,lst3
                };
    
                Console.WriteLine("Original list:");
                PrintList(allList);
    
                var sortedList = allList.OrderBy(lst => lst.FirstOrDefault()?.Key).ToList();
    
                Console.WriteLine("Sorted List");
                PrintList(sortedList);
    
                Console.ReadKey();
            }
    
            static void PrintList(List<List<Sig>> allList)
            {
                foreach (var lst in allList)
                {
                    Console.WriteLine("List 1");
                    foreach (var l in lst)
                    {
                        Console.WriteLine($"Key:{l.Key} Value:{l.Value}");
                    }
                }
            }
        }
    
        public class Sig
        {
            public int Key { get; set; }
            public string Value { get; set; }
        }
    }
