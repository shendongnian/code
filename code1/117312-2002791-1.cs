    public class  DetailFinder
    {
        private static Dictionary<string,Func<DetailFinder>> Creators;
        static DetailFinder()
        {
             Creators = new Dictionary<string,Func<DetailFinder>>();
             Creators.Add( "Planning", CreatePlanningFinder );
             Creators.Add( "Operations", CreateOperationsFinder );
             ...
        }
        public static DetailFinder Create( string type )
        {
             return Creators[type].Invoke();
        }
        private static DetailFinder CreatePlanningFinder()
        {
            return new PlanningFinder();
        }
        private static DetailFinder CreateOperationsFinder()
        {
            return new OperationsFinder();
        }
        ...
