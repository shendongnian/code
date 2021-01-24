            const int numberOfTests = 4;
            int[] array = new int[numberOfTests];
            for (int count = 0; count < numberOfTests; count++)
            {
                Console.WriteLine("Please enter test score " + count);
                try
                {
                    int answer = Convert.ToInt32(Console.Read());
                    if (answer > 0 && answer < 101)
                    {
                        array[count] = answer;
                    }else{
                        Console.WriteLine("Please provide a value between 1-100");
                    }
                }catch{
                    Console.WriteLine("Please provide an integer";
                }
            }
