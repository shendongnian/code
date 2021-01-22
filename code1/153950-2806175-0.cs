    public class Data 
    {
        public string value1 {get;set;}
        // add more properties here
    }
    
    public class GetInputParameters
    {
        public Data GetParameters()
        {
            var d = new Data();
            d.value1 = Console.ReadLine();
            return d;
        }
    }
    
    
    public class InsertToDatabase
    {
        public void InsertRecord(Data value)
        {
            // database persistance code
        }
    }
