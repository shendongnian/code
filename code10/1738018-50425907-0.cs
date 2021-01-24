            int higher = 43;
            int lower = 21;
            int[] numbers = new int[22]; //the numbers between 21 and 43 are 22
            for (int i = lower+1; i < higher; i++)
            {
                
                    numbers[i-lower] = i;
                
                
                
            }
            for (int c = 1; c < 21; c++)
            {
                Console.WriteLine(numbers[c]);
            }
            Console.ReadLine();
