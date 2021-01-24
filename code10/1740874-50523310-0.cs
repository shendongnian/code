    int[] x = new int[20];
    Random rnd = new Random();
    // You don't know the length of y,
    // so you can't use arrays. Use List<>
    List<int> y = new List<int>();
    // First initialize
    for (int i = 0; i < x.Length; i++)
    {
        x[i] = rnd.Next(1, 15);
    }
    // Then scan
    for (int i = 0; i < x.Length; i++)
    { 
        for (int j = i + 1; j < x.Length; j++)
        {
            if (x[i] == x[j])
            {
                y.Add(x[i]);
                Console.WriteLine("Repeated numbers is " + x[i]);
            }
        }
    }
    // Success/failure in finding repeated numbers can be decided only at the end of the scan
    if (y.Count == 0)
    {
        Console.WriteLine("There is no repeated numbers, numbers that are in x are");
        for (int i = 0; i < x.Length; i++)
        {
            Console.WriteLine(x[i]);
        }
    }
