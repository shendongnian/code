    int makeArrayConsecutive(int[] statues) 
    {
    
    Array.Sort(statues);    
    HashSet<int> set = new HashSet<int>();
        
    for(int i = statues[0]; i< statues[statues.Length -1]; i++)
     {
      set.Add(i);
     }
    
    for (int i = 0; i < statues.Length; i++)
    {
     set.Remove(statues[i]);
    }
    var x = set.Count;    
    return x;
    // return set ; // use this if you need the actual elements + change the method return type        
    }
