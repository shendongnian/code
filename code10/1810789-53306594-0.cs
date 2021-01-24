        public static int[] GetFirstEvenNumbers(int count)
        {
            int[] array = new int[count];
            for (int i = 1; i <= array.Length; i++)
                array[i - 1] = i * 2;
            // if you don't need to repeat the result twice get rid off the 
            // second for loop and Console.Write
            for (int j = 0; j < count; j++)
                Console.Write(array[j] + " ");
            return array;
        }
        public static void Main(string[] args)
        {
            Console.Write(string.Join(",",GetFirstEvenNumbers(5)));
            Console.ReadKey();
        } 
