        static void Main(string[] args)
        {
            ArrayList LA = new ArrayList() { 1, 3, 5, 7, 8 };
            Console.WriteLine("The Original array elements are:" + string.Join(",", LA.ToArray()));
            int item = 10, k = 3;
            LA.Insert(k, item);
            Console.WriteLine("The array elements after insertion:" + string.Join(",", LA.ToArray()));
            Console.ReadKey();
        }
