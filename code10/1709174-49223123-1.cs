    public static int Number()
    {
        bool done = false;
        while (done == false)
        {
            try
            {
                string[] numbers = { "1", "2", "3", "4", "5", "6" };
                Console.WriteLine("Enter a number");
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine(numbers[x]);
                Console.ReadLine();
                return x;  //THIS IS PREVENTING THE NEXT LINE
                done = true;
            }
            catch
            {
                Console.WriteLine("can't");
            }
        }
    }
