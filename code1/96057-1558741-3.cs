    public class MyGraph : IGraph
    {
         private readonly IGraph _initial;
         public MyGraph(IGraph initial)
         {
             _initial = initial;
         }
         IEnumerable<Client> GetClients()
         {
              foreach (Client c in _initial.GetClients())
                  yield return new MyClient(c);
         }
    }
