    public int ChooseNextColor(int numColors)
    {
        while (true)
        {
            Console.Write("Please enter your next color selection: ");
            string input = Console.ReadLine();
            int color;
            if (!int.TryParse(input, out color) || color > numColors || color < 0)
            {
                Console.WriteLine("Unrecognized input: " + input);
                Console.WriteLine("Please enter a value between 0 and " + numColors + ".");
            }
            else
            {
                return color;
            }
        }
    }
