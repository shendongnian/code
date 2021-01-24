    for (int i = 0; i < vnos.Count - 1; i++)
    {
    	if (operacije[i] == '*')
    	{
    		vnos[i] = vnos[i] * vnos[i + 1];
    		vnos.RemoveAt(i + 1);
    		operacije.RemoveAt(i);
    	}
    	else if (operacije[i] == '/')
    	{
    		vnos[i] = vnos[i] / vnos[i + 1];
    		vnos.RemoveAt(i + 1);
    		operacije.RemoveAt(i);
    	}
    }
