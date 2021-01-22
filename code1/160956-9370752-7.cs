    private static string SerializeValue(object value)
    {
      if (!(value is IConvertible))
        throw new InvalidCastException(
          string.Format("The type '{0}' is not supported.", value.GetType()));
      var convertible = (IConvertible)value;
      var str = convertible.ToString(CultureInfo.InvariantCulture);
      //uncomment if you're serializing to XML
      //return HttpUtility.HtmlEncode(str);
      return str;
    }
