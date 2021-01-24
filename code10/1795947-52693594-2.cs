    public void DeleteBelow(float threshold)
    {
         foreach(var x in myList.Where(x => x < threshold).ToList())
              myList.Remove(x); 
    }
    
    public void DeleteAbove(float threshold)
    {
         foreach(var x in myList.Where(x => x > threshold).ToList())
              myList.Remove(x); 
    }
    
    public int CountBelow(float threshold)
    {
         return myList.Count(x => x < threshold);
    }
    
    public int CountAbove(float threshold)
    {
         return myList.Count(x => x > threshold);
    }
