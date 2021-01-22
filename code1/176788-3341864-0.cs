    public class Data
    {
         public Data()
         {
            // set local variable to value stored in the database via a query
         }
    
         public string Prop1
         {
               get
               {
                    // return the value in local variable
               }
               set
               {
                    // Save the data to local variable
               }
         }
    
         public void SaveData()
         {
              // Write all the properties to a file
         }
    
    }
    
    class Program
    {
        public void SaveData()
        {
             Data d = new Data();
             d.Prop1 = //prop1 type from program; 
             d.SaveData();
        }
    }
