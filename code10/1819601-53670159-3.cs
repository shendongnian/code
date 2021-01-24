    public class Operator : IAction
    {
        public string Operator {get;set;}
    }
    public class Calculation : IAction
    {
        IList<KeyValuePair<IAction, Property>> Operations {get;set;}
    }
