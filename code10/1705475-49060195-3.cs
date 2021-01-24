    private static void PrintArray(int[] array)
    {
        if (array == null)
        {
            Console.WriteLine("The array is null - nothing to print.");
        }
        else
        {
            Console.WriteLine("Here are the array items:");
            foreach (int number in array)
            {
                Console.WriteLine(number);
            }
        }
    }
