	public static void Main()
	{ 
		int row=0 , col=0;
		int[,] array = new int[,]
		{
		 { 1, 2, 3 },
		 { 4, 5, 6 }, 
		 { 7, 8, 9 },
		 { 10, 11, 12 } 
		};
		
		int flag=0;
		
		for (int i = 0; i < array.Rank; i++)
		{
					if(flag==0)
					{
			row= array.GetLength(i);
						flag=1;
					}
					else
					{
						
			 col= array.GetLength(i);		
					}
			
			}
		
		Dictionary<int,int[,]> dictionary = new Dictionary<int, int[,]>();
		
		for(int i=0;i<row;i++)
		{
			
			dictionary.Add(array[i,0],new int[, ]{{array[i,1]},{array[i,2]}});
					
		}
		
		Console.WriteLine(dictionary[4].GetValue(0,0));
		
	}
