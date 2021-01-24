    public static List<int> Conversor(string stringFromDatabase)
    {
    	byte[] byteArray = Convert.FromBase64String(stringFromDatabase);
    
    	List<int> retorno = new List<int>();
    
    	for (int i = 0; i < byteArray.Length; i++)
    	{
    		if ((char)byteArray[i] == (char)105)
    		{
    			int valInt = 0;
    			int primeiroByte = Convert.ToInt32(byteArray[i + 1]);
    			if (primeiroByte == 0)
    				retorno.Add(0);
    			else if (primeiroByte > 4)
    				retorno.Add(primeiroByte - 5);
    			else if (primeiroByte > 0 && primeiroByte < 5)
    			{
    				valInt = byteArray[i + 2];
    				for (int y = 1; y < primeiroByte; y++)
    				{
    					valInt = valInt | (byteArray[i + 2 + y] << 8 * y);
    				}
    				retorno.Add(valInt);
    			}
    
    		}
    	}
    
    	return retorno;
    }
