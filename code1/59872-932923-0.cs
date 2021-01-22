    public class Attribute { public string Name { get; set; } }
    public class AttributeCollection : KeyedCollection<string, Attribute> {
        public AttributeCollection() : base(StringComparer.OrdinalIgnoreCase) { }
        protected override string GetKeyForItem(Attribute item) { return item.Name; }
    }
    public class ClassWithAttributes {
        private AttributeCollection _attributes;
        public void AddAttribute(Attribute attribute) {
            _attributes.Add(attribute);    
            //KeyedCollection will throw an exception
            //if there is already an attribute with 
            //the same (case insensitive) name.
        }
    }
