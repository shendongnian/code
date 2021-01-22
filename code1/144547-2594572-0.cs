    class Program
    {
        static void Main()
        {
            GeneratePossibilites(new int[] {3, 2, 1}, 10, 0, new List<int>());
        }
        static void GeneratePossibilites(int[] array, int maxSum, int crSum, List<int> stack)
        {
            for (int i = 0; i < stack.Count; ++i )
                Console.Write(array[ stack[i] ].ToString() + " ");
            Console.WriteLine();
            int start = 0;
            if (stack.Count > 0)
                start = stack[stack.Count - 1];
            for (int i = start; i < array.Length; ++i)
                if (crSum + array[i] < maxSum)
                {
                    stack.Add(i);
                    GeneratePossibilites(array, maxSum, crSum + array[i], stack);
                    stack.RemoveAt(stack.Count - 1);
                }
        }
    }
