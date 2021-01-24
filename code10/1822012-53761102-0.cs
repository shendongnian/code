    class Program
    {
        static int GetMulResult(int[] input, int ommitingIndex)
        {
            int result = 1;
            for(int i = 0; i < input.Length; i++)
            {
                if (i == ommitingIndex)
                    continue;
                result *= input[i];
            }
            return result;
        }
        static void Main(string[] args)
        {
            int[] inputArray = { 2, 3, 6, 8 };
            int[] result1 = new int[4];
            
            for(int i = 0; i < inputArray.Length; i++)
                result1[i] = GetMulResult(inputArray, i);
            
        }
    }
