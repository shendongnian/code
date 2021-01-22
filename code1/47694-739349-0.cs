    public static void AddItems(object state_)
    {     
       for (int i = 1; i <= 50; i++)      
       {        
           _collection.Add(i.ToString());      
           Console.WriteLine("Adding " + i);  
       }   
    } 
