        // C#: INDEXER 
    using System; 
    using System.Collections; 
    
    class MyClass 
    { 
        private string []data = new string[5]; 
        public string this [int index] 
        { 
           get 
           { 
               return data[index]; 
           } 
           set 
           { 
               data[index] = value; 
           } 
        } 
    }
    
    class MyClient 
    { 
       public static void Main() 
       { 
          MyClass mc = new MyClass(); 
          mc[0] = "Rajesh"; 
          mc[1] = "A3-126"; 
          mc[2] = "Snehadara"; 
          mc[3] = "Irla"; 
          mc[4] = "Mumbai"; 
          Console.WriteLine("{0},{1},{2},{3},{4}",mc[0],mc[1],mc[2],mc[3],mc[4]); 
       } 
    } 
