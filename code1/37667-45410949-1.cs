    Console.WriteLine("Define Array Size? ");
    int number = Convert.ToInt32(Console.ReadLine());
    
    Console.WriteLine("Enter numbers:\n");
    int[] arr = new int[number];
    
    for (int i = 0; i < number; i++)
    {
    	arr[i] = Convert.ToInt32(Console.ReadLine());
    }
    for (int i = 0; i < arr.Length; i++ )
    {
    	Console.WriteLine("Array Index: "+i + " AND Array Item: " + arr[i].ToString());
    }
    Console.ReadKey();
