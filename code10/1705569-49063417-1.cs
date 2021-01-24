    public static void Main()
    {
        int[] arr = new int[10];
    
        int i = 0;//counter
        while(i<arr.Length)
        { 
            Console.Write("Enter an integer: ");
            if (int.TryParse(Console.ReadLine(), out arr[i]))
            {
                i++;
                Console.WriteLine("\nPress enter to continue!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\nYou didn't enter an integer!\n");
            }
        }
    }
