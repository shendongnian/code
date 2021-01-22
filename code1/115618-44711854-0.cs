    static int BinaryToDec(string input)
        {
            
            char[] array = input.ToCharArray();
            // Reverse since 16-8-4-2-1 not 1-2-4-8-16. 
            Array.Reverse(array);
            /*
             * [0] = 1
             * [1] = 2
             * [2] = 4
             * etc
             */
            int sum = 0; 
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] == '1')
                {
                    // Method uses raising 2 to the power of the index. 
                    if (i == 0)
                    {
                        sum += 1;
                    }
                    else
                    {
                        sum += (int)Math.Pow(2, i);
                    }
                }
                
            }
            return sum;
        }
