    int[] smallest = new int[one.Length]; 
    for (int i = 0; i < one.Length; i++)
    {
        if (one[i] < two[i])
        {
            smallest[i] = one[i];
        }
        else 
        {
            smallest[i] = two[i];
        }
    }
