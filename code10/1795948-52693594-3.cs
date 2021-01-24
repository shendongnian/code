    public void DeleteBelow(float threshold)
    {
              myList.RemoveAll(x => x < threshold); 
    }
    
    public void DeleteAbove(float threshold)
    {
              myList.RemoveAll(x => x > threshold); 
    }
    
    public int CountBelow(float threshold)
    {
         return myList.Count(x => x < threshold);
    }
    
    public int CountAbove(float threshold)
    {
         return myList.Count(x => x > threshold);
    }
