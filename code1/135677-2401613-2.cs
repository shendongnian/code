    string[] array = new string[]{"big", "bad", "dog"};
    for(ulong mask = 0; mask < (1ul << array.Length); mask++)
    {
        string permutation = "";
        for(int i = 0; i < array.Length;  i++)
        {
            if((mask & (1ul << (array.Length - 1 - i))) != 0)
            {
                permutation += array[i] + " ";
            }
        }
        Console.WriteLine(permutation);
    }
