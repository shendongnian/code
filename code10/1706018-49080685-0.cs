    static void Main(string[] args)
        {
            Console.WriteLine("What is the High Water Mark? ");
            int high_water = Convert.ToInt32(Console.ReadLine());
            int percent = 0;
            while (percent < 100)
            {
                Console.WriteLine("What is the Low Water Mark? ");
                int low_water = Convert.ToInt32(Console.ReadLine());
                double ratio = (double)low_water / high_water;
                percent = (int) Math.Round(ratio * 100);
                Console.WriteLine(percent);
            }
            Console.WriteLine("Operation Complete");
        }
