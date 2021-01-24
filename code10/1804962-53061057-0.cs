    public abstract class BaseClass
    {
        public string Property1 { get; }
        public int Property2 { get; }
        public BaseClass(string prop1, int prop2)
        {
            ...
        }
    }
    public class StringClass : BaseClass
    {
        public int SortIndex { get; }
        public StringClass(string prop1, int prop2, int index) :
            base(prop1, prop2)
        {
            SortIndex = index;
        }
    }
    public class CollectionClass : BaseClass
    {
        public Dictionary<string, int>  SortIndexes { get;}
        public CollectionClass(string prop1, int prop2, Dictionary<string, int> indexes) :
            base(prop1, prop2)
        {
            SortIndexes = indexes;
        }
    } 
