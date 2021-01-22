    public class MyCollections
    {
        public System.Collections.Generic.IEnumerable<SomeType> SomeTypeCollection;
        public System.Collections.Generic.IEnumerable<OtherType> OtherTypeCollection;
    
        public int CountSomeTypeCollection
        {
            get { return this.SomeTypeCollection.Count(); }
        }
        ...
