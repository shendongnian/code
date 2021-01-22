    using System;
    
    public class MyDataset
    {
       private static MyDataset instance;
       
       // TODO: add property that is holding the dataset
    
       private MyDataset() {}
    
       public static MyDataset Instance
       {
          get 
          {
             if (instance == null)
             {
                instance = new MyDataset();
             }
             return instance;
          }
       }
    }
