    static void Main(string[] args)
    {
        int[] myArray = new int[10];
        while (true)
        {
            int enteredNumber;           
            // int[] myArray = new int[10]; //when you create a new int array , the array not contain values.
            Startmenu();
            enteredNumber = Convert.ToInt32(Console.ReadLine());
            if (enteredNumber == 1)
            {                    
                for (int i = 0; i < 1; i++)
                {
                    Console.WriteLine("Insert Number:");
                    myArray[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.Clear();
                Console.WriteLine("blabla");
                Thread.Sleep(2000);
                Console.Clear();
            }
            if (enteredNumber == 9)
            {
                if (Login(1234, 3) == true)
                {
                    foreach (int number in myArray)
                    {
                        Console.WriteLine(number);
                    }
                }
            }
        } 
    }
