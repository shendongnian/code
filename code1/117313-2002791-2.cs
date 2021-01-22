    public class DetailFinder
    {
          private static Dictionary<string,Type> Creators;
          static DetailFinder()
          {
               Creators = new Dictionary<string,Type>();
               Creators.Add( "Planning", typeof(PlanningFinder) );
               ...
          }
          public static DetailFinder Create( string type )
          {
               Type t = Creators[type];
               return Activator.CreateInstance(t) as DetailFinder;
          }
    }
