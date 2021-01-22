    protected int this[int index]
    {
    	get
    	{
    		int tempN = Number;
    		if (index > 0)
    		{
    			tempN /= index * 10;
    		}
    		return tempN % 10;
    	}
    }
