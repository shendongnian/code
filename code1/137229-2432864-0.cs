    public class Derived : Base
    {
        private IEnumerable<string> GetBaseStuff()
        {
            return base.GetListOfStuff();
        }
    
        public override IEnumerable<string> GetListOfStuff()
        {
            foreach (string s in GetBaseStuff())
            {
                yield return s;
            }
    
            yield return "Fourth";
            yield return "Fifth";
        }
    }
