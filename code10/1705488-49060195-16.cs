    private static void PrintArray(int[] array)
    {
        if (array == null)
        {
            Console.WriteLine("The array is null - nothing to print.");
        }
        else
        {
            Console.WriteLine("Here are the array items entered:");
            for (int i = 0; i < NextIndexToPopulate; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
