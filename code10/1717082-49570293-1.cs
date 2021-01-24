    public static void ShuffleMe<T>(this IList<T> list)  
    {  
    	Random random = new Random();  
        int n = list.Count;  
    
    	for(int i= list.Count - 1; i > 1; i--)
    	{
    		int rnd = random.Next(i + 1);  
            
    		T value = list[rnd];  
            list[rnd] = list[i];  
            list[i] = value;
    	}
    }
    List<Color> colors = new List<Color> ();
    colors.Add(Color.Black);
    colors.Add(Color.White);
    colors.Add(Color.Red);
    colors.ShuffleMe();
