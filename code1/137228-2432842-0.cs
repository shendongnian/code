    public class Derived : Base
    {
        public override IEnumerable<string> GetListOfStuff()
        {
            return base.GetListOfStuff().Concat(GetMoreStuff());        
        }
        private IEnumerable<string> GetMoreStuff()
        {
            yield return "Fourth";
            yield return "Fifth";
        }
    }
