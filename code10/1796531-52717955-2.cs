    class DiffPropertyInfo<TSource>
    {
        public int Id {get; set;}
        public TSource OriginalValue {get; set;}
        public TSource AlternativeValues {get; set;}
        public PropertyInfo PropertyInfo {get; set;}
        public object OriginalPropertyValue
        {
            get {return this.PropertyInfo.GetValue(this.OriginalValue);}
        }
        public object AlternativePropertyValue
        {
            get { return this.PropertyInfo.GetValue(this.AlternativeValue); }
        }
        public bool IsChanged()
        {
            object originalPropertyValue = this.OriginalPropertyValue;
            object alternativePropertyValue = this.AlternativePropertyValue;
            return Object.Equals(originalPropertyValue, alternativePropertyValue);
        }
    }
