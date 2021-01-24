    int[] a = {1, 2, 45, 4, 5, 6, 7};
    int[] b = new int[7];
		
	for (int i = 0, j = b.Length - 1; i < a.Length; i++, j--)
    {
        b[i] = a[j];
        Console.WriteLine(b[i]);
    }
