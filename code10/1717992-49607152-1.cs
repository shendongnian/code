    public class Predicate
    {
        public string Field { get; set; }
        public Operator Operator { get; set; }
        public string Value { get; set; }
    }
    public enum NormalForm
    {
        Conjunctive,
        Disjunctive
    }
    public class Filter
    {
        public NormalForm NormalForm { get; set; }
        public List<List<Predicate>> Predicates { get; set; }
    }
