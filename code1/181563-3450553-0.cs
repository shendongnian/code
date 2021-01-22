       public class BStringConvertor : TypeConverter
       {
          public BStringConvertor()
             : base()
          {
          }
    
          public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
          {
             // Allow conversion from a String type
             if (sourceType == typeof(string))
                return true;
    
             return base.CanConvertFrom(context, sourceType);
          }
    
          public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
          {
             // If the source value is a String, convert it to the "B" class type
             if (value is string)
             {
                B item = new B();
                item.Title = value.ToString();
                return item;
             }
             return base.ConvertFrom(context, culture, value);
          }
    
          public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
          {
             // If the destination type is a String, convert the "B" class to a string
             if (destinationType == typeof(string))
                return value.ToString();
    
             return base.ConvertTo(context, culture, value, destinationType);
          }
       }
