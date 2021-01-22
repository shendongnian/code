    public class KVPCycle
    {
       Queue<KeyValuePair<int, string>> queue; 
       
       public KVPCycle(IEnumerable<KeyValuePair<int, string>> items)
       {
           queue = new Queue<KeyValuePair<int, string>>(items);
       }
       
       public KeyValuePair<int, string> Next()
       {
        var item = queue.Dequeue();
        queue.Enqueue(item);
        return item;
       }
       
    }
