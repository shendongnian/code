    class Program
        {
            static void Main(string[] args)
            {
                Rectangle rec = new Rectangle(8, 10);
                Square squ = new Square(11, 12);
                squ.ComputeArea();
                Triangle tri = new Triangle(10, 20);
                tri.ComputeArea();
                Console.WriteLine("Computed area is {0}" + "\n\n" + "Computed Triangle is: {1}" + "\n",
                squ.Area, tri.Area);
                Console.ReadLine();
            }
        }
