    class Program
    {
        static void Main(string[] args)
        {
            int[,] myArray = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            var e = myArray.GetEnumerator();
            e.Reset();
            while (e.MoveNext())
            {
                // this will output each number from 1 to 6. 
                Console.WriteLine(e.Current.ToString());
            }
            Console.ReadLine();
        }
    }
