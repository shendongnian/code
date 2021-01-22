    static void Main(string[] args)
    
            {
    
                var results = new List<oObject>
    
                                                {
    
                                                    new oObject {Value1 = "A", Value2 = "B"},
    
                                                    new oObject {Value1 = "B", Value2 = "A"}
    
                                                };
    
     
    
                IEnumerable<oObject> query = results.OrderBy("Value2", false);
    
                foreach (oObject o in query)
    
                {
    
                    Console.WriteLine(o.Value1 + ", " + o.Value2);
    
                }
    
                Console.WriteLine(Environment.NewLine);
    
                IEnumerable<oObject> query2 = results.OrderBy("Value1", false);
    
                foreach (oObject o in query2)
    
                {
    
                    Console.WriteLine(o.Value1 + ", " + o.Value2);
    
                }
    
                Console.ReadLine();
    
            }
 
