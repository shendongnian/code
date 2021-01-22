     namespace BinaryExample1
            {
            class Program
            {
            static void Main(string[] args)
            {
            int i = Convert.ToInt32("01000100", 2);
            int j = Convert.ToInt32("00000100", 2);
            int z;
            z = i / j;
            Console.WriteLine(z);
            Console.ReadLine();
            }
            }
            }
