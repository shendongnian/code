    int max = Int32.MinValue;
    int nextMax = Int32.MinValue;
    
    for(int i=0; i<list.Count(); i++)
    {
      if(list[i] > max)
      {
        nextMax = max;
        max = list[i]; 
      }
      else if(list[i] > nextMax)
      {
        nextMax = list[i];
      }
    }
