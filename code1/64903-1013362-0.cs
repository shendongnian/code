    public enum Operation
    {
        And,
        Or
    }
    
    public class QueryObject
    {
        public string Value { get; set; }
        public Type Type { get; set; }
        public Operation Operation { get; set; }
    }
    
    public override IEnumerable<T> SelectQuery(Dictionary<string, QueryObject> dictionary)
    {
        string t = Convert.ToString(typeof(T).Name);
        string criteria = string.Empty;
        foreach (KeyValuePair<string, QueryObject> item in dictionary)
        {
            if (!string.IsNullOrEmpty(criteria))
            {
                switch (item.Value.Operation)
                {
                    case Operation.And:
                        criteria += " and ";
                        break;
                    case Operation.Or:
                        criteria += " or ";
                        break;
                    default:
                        break;
                }
            }
    
            if (item.Value.Type == typeof(int))
            {
                criteria += item.Key + " = " + item.Value + " ";    
            }
            else
            {
                criteria += item.Key + " = '" + item.Value + "'";
            }
        }
    
        string query = " from " + t;
    
        if (criteria != string.Empty)
            query += " where " + criteria;
    
        return FindByHql(query);
    }
