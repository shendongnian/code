    public struct PropertyValue {
        public PropertyValue( string propertyName, string value) 
        { 
            this.PropertyName = propertyName;
            this.Value = this.value;
        }
        private PropertyValue( params string[] pv) => PropertyValue(pv[0], pv[1]);
        public string PropertyName {get;}
        public string Value {get;}
        override public string ToString() => this.PropertyName + ":" + this.Value;
        public static PropertyValue FromString(string pv) => return new PropertyValue( pv.Split(":"));
    }
