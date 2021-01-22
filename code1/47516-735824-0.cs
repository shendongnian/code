    [TypeConverter(typeof(FooConverter))]
    class Foo { }
    
    class FooConverter : ExpandableObjectConverter
    {
        public override PropertyDescriptorCollection GetProperties(
           ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            // your code here, perhaps using base.GetPoperties(
            //    context, value, attributes);
        }
    }
