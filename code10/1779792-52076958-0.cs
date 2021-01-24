    using Newtonsoft.Json;
    
    namespace MyNamespace
    {
    
        class Program
        {
            static void Main(string[] args)
            {
    
                //your input list
                List<string> animals = new List<string> { "Dog", "Cat", "Mouse" };
                var json = JsonConvert.SerializeObject(animals);
                //call your web API by passing this JSON along with your token
    	    }
         }
    } 
 
