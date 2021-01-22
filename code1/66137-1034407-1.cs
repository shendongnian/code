    public class Program
 {
     public IEnumerable<SomeClass> GetObjects(int anchor, int chunkSize)
     {
         var list = new List<SomeClass>();
         while( // get implementation for given anchor and chunkSize
             list.Add(object);
         }
         return list;
     }
     public void ProcessObjects(IEnumerable<SomeClass> objects)
     {
         foreach(var object in objects)
             // process implementation
     }
     void Main()
     {
         int chunkSize = 5000;
         int totalSize = //Get Total Number of rows;
         int anchor = //Get first row to process as anchor;
         While (anchor < totalSize)
         (
             var objects = GetObjects(anchor, chunkSize);
             ProcessObjects(objects);
             anchor += chunkSize;
         }
     }
