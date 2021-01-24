    public static void Main()
    {
        int i,n;
        Console.WriteLine("Enter the number of highest elements you want to extract from the array:");
        while (!int.TryParse(Console.ReadLine(), out n))
        {
            Console.WriteLine("Enter the number of highest elements you want to extract from the array:");
        }
        double[] result = new double[n];
        double[] arr = { 12.1, 5.9, 2.9, 6.8, 20.5 };
        double max = 0;
        int index;
        for (int j = 0; j < n; j++)
        {
            max = arr[0];
            index = 0;
            for (i = 1; i < arr.Length; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                    index = i;
                }
            }
            result[j] = max;
            arr[index] = Double.MinValue;
    
            Console.WriteLine("Highest numbers: {0}", result[j]);
        }
        Console.ReadKey();
    }
