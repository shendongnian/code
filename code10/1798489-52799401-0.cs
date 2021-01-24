            const int SIZE = 4;
            int[] array = new int[SIZE];
            while (array.Length < 4)
            {
                int count = array.Length + 1;
                Console.WriteLine("Please enter test score " + count);
                try
                {
                    int answer = Convert.ToInt32(Console.Read());
       
                }
                catch
                {
                    Console.WriteLine("Please provide an integer";
                }
                if (answer > 0 && answer < 101)
                {
                    array[count] = answer;
                }else{
                   Console.WriteLine("Please provide a value between 1-100";
                }
            }
