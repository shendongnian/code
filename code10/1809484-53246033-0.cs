        Console.Write("type a sentence: ");
        String str = Console.ReadLine();
        char[] arr = str.ToCharArray();
		
		int[] count = new int[10000];
        for (int j = 0; j < arr.Length; j++)
        {
            count[arr[j]]++;
        }
		
		int ans=0;
		for (int j = 0; j < count.Length; j++)
        {
            if(count[j]>1)
			{
				ans++;				
			}
        }
		
		Console.WriteLine("Number of duplicates: " + ans +" duplicates are: ");
		Console.WriteLine("Duplicates are: ");
		
		
		for (int j = 0; j < count.Length; j++)
        {
            if(count[j]>1)
			{
				Console.WriteLine((char)j);
			}
        }
