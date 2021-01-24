    class Program
        {
            static void Main(string[] args)
            {
                int[][] values = new int[5][];
                values[0]= new int[] { 1, 32, 1024 };
                values[1] = new int[] { 2, 64, 2048 };
                values[2] = new int[] { 4, 128, 4096 };
                values[3] = new int[] { 8, 256, 8192 };
                values[4] = new int[] { 16, 512, 16384 };
    
                int[] result = values[0]; 
    
                for(int i = 1; i < values.GetLength(0); i++)
                {
                    result = Multiply2Arrays(result, values[i]);
                }
            }
    
            private static int[] Multiply2Arrays(int[] array1, int[] array2)
            {
                int[] result = new int[array1.Length * array2.Length];
                int counter = 0;
                for (int i = 0; i < array1.Length; i++)
                {
                    for (int j = 0; j < array2.Length; j++)
                    {
                        result[counter] = array1[i] + array2[j];
                        counter++;
                    }
                }
                return result;
            }
        }
