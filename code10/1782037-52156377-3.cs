    int[] arr = { 3, 1, 2, 2, 1, 2, 3, 3 };
    int k = 4;
    
    for(int i = 0; i < arr.Length; i++)
    {
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
