    public static int Number()
    {
        bool done = false;
        int x = 0;
        while (done == false)
        {
            try
            {
                string[] numbers = { "1", "2", "3", "4", "5", "6" };
                Console.WriteLine("Enter a number");
                x = int.Parse(Console.ReadLine());
                Console.WriteLine(numbers[x]);
                Console.ReadLine();
                done = true;
            }
            catch
            {
                Console.WriteLine("can't");
            }
            
        }
        return x;
    }
