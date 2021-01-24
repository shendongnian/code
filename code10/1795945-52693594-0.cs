    public void DeleteBelow(float threshold)
    {
         foreach(var x in myList.Where(x => x < threshold))
              myList.Remove(x); 
    }
    
    public void DeleteAbove(float threshold)
    {
         foreach(var x in myList.Where(x => x > threshold))
              myList.Remove(x); 
    }
    
    public void CountBelow(float threshold)
    {
         myList.Count(x => x < threshold);
    }
    
    public void CountAbove(float threshold)
    {
         myList.Count(x => x > threshold);
    }
