    int[] arr = { 3, 1, 2, 2, 1, 2, 3, 3 };
    int k = 4;
    HashSet<int> seen  = new HashSet<int>();
    
    for(int i = 0; i < arr.Length; i++)
    {
        if(!seen.Add(arr[i]))
        {
            continue;
        }
    	int count = 1;
        for (int j = i + 1; j < arr.Length; j++)
        {
            if (arr[i] == arr[j])
            {
                count++;
                if (count > (arr.Length / k))
                {
                    Console.WriteLine(arr[i] + " " + i );
                    break;
                }
            }
        }
    }
