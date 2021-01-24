    class Program {
        static Champion Aatrox { get; set; } = new Champion();
        static Champion Ahri { get; set; } = new Champion();
        static void Main(string[] args) {
            Console.WriteLine(Aatrox.Name);
            Console.WriteLine(Ahri.Name);
            Console.ReadLine();
        }
    }
