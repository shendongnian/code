    public class MethodCollection
            {
                public static void Print(Action<int, int> printNumbers)
                {
                    printNumbers.Invoke(0,0);
                }
            }
        
            public class Program
            {
                static void Main(string[] args)
                {
                    MethodCollection.Print((p, q) => { Console.WriteLine((p=3) + (q=3)); });
                    Console.ReadLine();
        
                }
            }
