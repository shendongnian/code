    public class ConverterBoundField : BoundField
    {
        protected override string FormatDataValue(object dataValue, bool encode)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(dataValue.GetType());
            if (converter.CanConvertTo(typeof(string)))
            {
                return converter.ConvertToString(dataValue);
            }
            return base.FormatDataValue(dataValue, encode);
        }
    }
