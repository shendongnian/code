       const int SIZE = 4;
        int[] array = new int[SIZE];
        int numberOfTests = 4;
        for (int count = 0; count < numberOfTests; count++) // Start the count from 0-4
        {
            int min = 0;
            int max = 100;
            Console.WriteLine("Please enter test score " + count); 
            int a = Console.Readline();
            if (a > 0 && a < 101){
                array[count] = Console.Readline();
            }
        }
