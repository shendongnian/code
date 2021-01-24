    static void Main()
    {
        double[] arr = new double[5] { 12.1, 5.9, 2.9, 6.8, 20.5 };
    
        double temp = 0;
    
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr.Length - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    temp = arr[j + 1];
                    arr[j + 1] = arr[j];
                    arr[j] = temp;
                }
            }
        }
    
        int n;
    
        Console.WriteLine("Enter the number of highest elements you want to extract from the array:");
    
        while (!int.TryParse(Console.ReadLine(), out n))
        {
            Console.WriteLine("Enter the number of highest elements you want to extract from the array:");
        }
    
        for (int i = arr.Length-1; i > arr.Length - 1 - n; i--)
        {
            Console.WriteLine(arr[i]);
        }
    
        Console.ReadKey();
    }
