    int[,] arr = new int[n,n];
    for(int i = 0; i < n; i++)
    {
        for(int j = 0; j < n; j++)
        {
            if(i+j-1 == n)
            {
                arr[i,j] = j+1;
            }
            else
            {
                arr[i,j] = 0;
            }
            Console.Write(arr[i,j] + " ");
        }
    Console.WriteLine();
    }
