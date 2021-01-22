    /// <summary>
    /// Gets a nullable value.
    /// </summary>
    /// <param name="aValue">The value to be converted.</param>
    /// <returns>The converted value.</returns>
    public static Nullable<decimal> ToDecimal(object aValue)
    {
       return ToNullable<decimal>(aValue,
         delegate(object aConvertableValue)
         {
            return Convert.ToDecimal(aConvertableValue);
         });
    }
    
    /// <summary>
    /// Converts the given value if necessary.
    /// </summary>
    /// <param name="aValue">A value from the database.</param>
    /// <param name="aConversion">A conversion delegate.</param>
    /// <returns>null, or the given value.</returns>
    private static Nullable<T> ToNullable<T>(
            object aValue, Converter<T> aConverter) where T : struct
    {
      if (aValue == DBNull.Value || aValue == null)
         return null;
      else if (aValue is T)
         return (T)aValue;
      else
         return aConverter(aValue);
    }
