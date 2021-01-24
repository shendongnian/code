    public enum LogicalOperator { OR, AND }
    public class FilterType
    {
        public string name {get;set;}
        public int id {get;set}
        public LogicalOperator ConditionType {get;set;}
        public List<FilterType> fl {get;private set;} = new List<FilterType>();
        public IEnumerable<FilterType> Descendants {
            get 
            {
                foreach(var f in fl)
                {
                    yield return f;
                    foreach(var child in f.Descendants)
                    {
                        yield return child;
                    }
                }
            }
        }  
    }
