    [TypeConverter(typeof(ProductTypeConverter))]
    public class Product
    {
        public string Symbol { get; set; }
        //[TypeConverter(typeof(FieldListTypeConverter))]
        public FieldList Fields { get; set; }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public PartDetails Details { get; set; }
    }
