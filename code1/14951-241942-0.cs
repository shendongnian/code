    public class AgeWrapperConverter : ExpandableObjectConverter
    {
      public override bool CanConvertTo(ITypeDescriptorContext context, 
                                        Type destinationType)
      {
        // Can always convert to a string representation
        if (destinationType == typeof(string))
          return true;
        // Let base class do standard processing
        return base.CanConvertTo(context, destinationType);
      }
      public override object ConvertTo(ITypeDescriptorContext context, 
                                       System.Globalization.CultureInfo culture, 
                                       object value, 
                                       Type destinationType)
      {
        // Can always convert to a string representation
        if (destinationType == typeof(string))
        {
          AgeWrapper wrapper = (AgeWrapper)value;
          return "Age is " + wrapper.Age.ToString();
        }
            
        // Let base class attempt other conversions
        return base.ConvertTo(context, culture, value, destinationType);
      }  
    }
