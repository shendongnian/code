    class Program
    {
        static void Main(string[] args)
        {
            //Memory usage 7.1 MB
            Console.WriteLine("Hit enter to allocate");
            Console.ReadKey();
            byte[] data = new byte[1024*1024]; //Memory still 7.1 MB
            Console.WriteLine("Hit Enter to Fill with zeros!");
            Console.ReadKey();
            Array.Clear(data, 0, data.Length); //Memory now 8.1 MB
            Console.WriteLine("1MB filled, hit enter to exit");
            Console.ReadKey();
        }
    }
