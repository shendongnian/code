            const int SIZE = 4;
            int[] array = new int[SIZE];
            int numberOfTests = 4;
            for (int count = 0; count < numberOfTests; count++) // Start the count from 0-4
            {
                int min = 0;
                int max = 100;
                int countf = count + 1;
                Console.WriteLine("Please enter test score " + countf);
                int a = Convert.ToInt32(Console.ReadLine());
                if (a > 0 && a < 101)
                {
                    array[count] = a;
                }
            }
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine(array[0]);
            Console.WriteLine(array[1]);
            Console.WriteLine(array[2]);
            Console.WriteLine(array[3]);
            Console.ReadLine();
