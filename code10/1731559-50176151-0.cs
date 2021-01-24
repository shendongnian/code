	int[] items = { 1, 2, 3, 7, 8, 9, 13, 16, 19, 23, 25, 26, 29, 31, 35, 36, 39, 45 };
	int[] indices = { 1, 3, 5, 6, 7, 9 };
	
	List<int> results = new List<int>();
	for (int i = 0; i < indices.Length; i++)
	{
         results.Add(items[indices[i]]);}
	}
