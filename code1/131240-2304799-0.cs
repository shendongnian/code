    static void Main(string[] args)
            {
                var method = typeof (Cow).GetMethod("TryParse");
    
                var cow = new Cow();           
    
                var inputParams = new object[] {"cow string", cow};
                
                method.Invoke(null, inputParams); 
       }
 
    class Cow
        {
            
        
        public static bool TryParse(string s, out Cow cow) 
        {
            cow = null; 
    
            Console.WriteLine("TryParse is called!");
    
            return false; 
        }
    
        }
