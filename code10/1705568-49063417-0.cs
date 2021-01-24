    public static void Main()
    {
        int[] arr = new int[10];
    
        int i = 0;//counter
        while(i<arr.Length)
        { 
            Console.WriteLine("Enter an integer: ");
            if (int.TryParse(Console.ReadLine(), out arr[i]))
            {
                i++;
                Console.WriteLine("Press enter to continue!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You didn't enter an integer!");
            }
        }
    }
