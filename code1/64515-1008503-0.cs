    public class TraversalData {
      // All the info you'd like to keep track of.
      public string Name;
      public string Attributes;
      // ...
    }
    
    Stack<TraversalData> data = ...
    
    // ...
    
    foreach (string dn in Directory.GetDirectories(dir)) {
      // Make a TraversalData out of the information you want to store.
      TraversalData td = // ...
    
      data.Push(td);
    }
