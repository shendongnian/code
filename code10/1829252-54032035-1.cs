    class MyClass  
    {  
       Hashtable table;  // CS0649  
       // You may have intended to initialize the variable to null  
       // Hashtable table = null;  
      
       // Or you may have meant to create an object here  
       // Hashtable table = new Hashtable();  
      
       public void Func(object o, string p)  
       {  
          // Or here  
          // table = new Hashtable();  
          table[p] = o;  
       }  
      
       public static void Main()  
       {  
       }  
    } 
