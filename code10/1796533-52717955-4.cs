    class PropertyComparisonCollection<TSource>
    {
        public int Id {get; set;}
        public TSource OriginalValue {get; set;}
        public TSource AlternativeValues {get; set;}
        // returns a sequence of changed properties:
        public IEnumerable<DiffPropertyInfo> GetChangedProperties()
        {
             // Use the function ExtractProperties defined above
             return Extractproperties(this.OriginalValue, this.AlternativeValue)
                 .Where(extractedpropery => extractedProperty.IsChanged());
        }
    }
