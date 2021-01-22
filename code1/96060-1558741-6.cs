    // note that this class doesn't implement IGraph anymore
    public class MyGraph
    {
         private readonly IGraph _initial;
         public MyGraph(IGraph initial)
         {
             _initial = initial;
         }
         IEnumerable<MyClient> GetClients()
         {
              foreach (Client c in _initial.GetClients())
                  yield return new MyClient(c);
         }
    }
