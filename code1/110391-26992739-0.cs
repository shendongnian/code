    public class CSharepointStoredResults : Dictionary<string, object>
    {
        public CSharepointStoredResults(Dictionary<string, object> SourceDict = null) 
        {
            // Populate class dictionary from passed dictionary. This allows for some degree of polymorphism sideways.
            // For instance it becomes possible to treat one CSharepointStoredResults as another (roughly like treating
            // a cat as a dog
            foreach (string key in SourceDict.Keys) { this.Add(key, SourceDict[key]); }
        }
        public Type MyType 
        {
            get {
                if (!__MyType && !this.ContainsKey(bObj.GetPropertyNameFromExpression(() => this.MyType)))
                {
                    // Neither a dictionary nor a field set
                    // return the field
                }
                else if (!__MyType)
                {
                    // There is a dictionary entry, but no volatile field set yet.
                    __MyType = true;
                    _MyType = this[bObj.GetPropertyNameFromExpression(() => this.MyType)] as Type;
                }
                else 
                {
                    // Volatile value assigned, therefore the better source. Update the dictionary  
                    this[bObj.GetPropertyNameFromExpression(() => this.MyType)] = _MyType;
                }
                return _MyType;
            }
            set {
                // Verify the value is valid...
                if (!(value.IsInstanceOfType(typeof(CSharepointStoredResults))))
                    throw new ArgumentException("MyType can only take an instance of a CSharePointResults object");
                _MyType = value;
                this[bObj.GetPropertyNameFromExpression(() => this.MyType)] = value;
            }
        }
        private volatile Type _MyType;
        private volatile bool __MyType;
   }
