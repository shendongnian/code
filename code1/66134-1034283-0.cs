     public class Program
     {
         public IEnumerable<SomeClass> GetObjects()
         {
             while( // get implementation
                 yield return object;
             }
         }
    
         public void ProcessObjects(IEnumerable<SomeClass> objects)
         {
             foreach(var object in objects)
                 // process implementation
         }
    
         void Main()
         {
             var objects = GetObjects();
             ProcessObjects(objects);
         }
     }
