     static void Main(string[] args)
     {
         var response = new Dictionary<string, List<Obj>>();
         var inputObjs = new List<Obj>();
    
         inputObjs.Add(new Obj("prop1", "value1"));
         inputObjs.Add(new Obj("prop2", "value2"));
    
         response.Add("Inputs", inputObjs);
    
         var serializedObj = JsonConvert.SerializeObject(response);
    
         Console.ReadKey();
     }
