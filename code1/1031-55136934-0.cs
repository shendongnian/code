CSHARP
public static class ConversionExtensions
{
        public static object Convert(this object value, Type t)
        {
            Type underlyingType = Nullable.GetUnderlyingType(t);
            if (underlyingType != null && value == null)
            {
                return null;
            }
            Type basetype = underlyingType == null ? t : underlyingType;
            return System.Convert.ChangeType(value, basetype);
        }
        public static T Convert<T>(this object value)
        {
            return (T)value.Convert(typeof(T));
        }
}
Examples
CSHARP
            string stringValue = null;
            int? intResult = stringValue.Convert<int?>();
            int? intValue = null;
            var strResult = intValue.Convert<string>();
  [1]: https://stackoverflow.com/questions/8625/generic-type-conversion-from-string/31883872#31883872
