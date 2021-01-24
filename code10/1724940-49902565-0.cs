    double index = 5;
    List<double> list = new List<double>() { 1, 2, 3, 7, 8, 9, };
    for(int i =1 ; i <= 9-5 ; i++)
    {
    	List<double> NextHigh = list.Where(x=> x-i == index).ToList();
    	if(! (NextHigh.Count == 0))
    	{
    		NextHigh.Dump();
    		break;
    	}
    }
    
    for(int i =1 ; i <= 5-1 ; i++)
    {
    	List<double> NextLow = list.Where(x=> x+i == index).ToList();
    	if( !(NextLow.Count== 0))
    	{
    		NextLow.Dump();
    		break;
    	}
    }
