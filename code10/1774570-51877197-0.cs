    {
    // ...
    var minKV = c.ToList()
    	.OrderBy(k => calcul_zero(k.Value))
    	.First();
    	
    Console.WriteLine(minKV.Key);
    //...
    }
    public static int calcul_zero(int[,] m)
    {
    	int zeros=0;
    	for (int i = 0; i < m.GetLength(0); i++)
    	{
    		for (int j = 0; j < m.GetLength(1); j++)
    		{
    			if (m[i, j] == 0) zeros++;
    		}
    	}
    	return zeros;
    } 
