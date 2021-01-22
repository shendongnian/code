    public class Thing
    {
       public static List<Thing> _things = new List<Thing>();
      
       public Thing()
       {
           _things.Add(this);
       }
    
       public static void SomeEventHandler(object value, EventHandler e)
       {
          foreach (Thing thing in _things)
          {
               // do something.
          }
       }
    }
