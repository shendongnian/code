<PRE>
/// &lt;summary&gt;
/// Gets a nullable value.
/// &lt;/summary&gt;
/// &lt;param name="aValue"&gt;The value to be converted.&lt;/param&gt;
/// &lt;returns&gt;The converted value.&lt;/returns&gt;
public static Nullable&lt;decimal&gt; ToDecimal(object aValue)
{
   return ToNullable&lt;decimal&gt;(aValue,
     delegate(object aConvertableValue)
     {
        return Convert.ToDecimal(aConvertableValue);
     });
}
/// &lt;summary&gt;
/// Converts the given value if necessary.
/// &lt;/summary&gt;
/// &lt;param name="aValue"&gt;A value from the database.&lt;/param&gt;
/// &lt;param name="aConversion"&gt;A conversion delegate.&lt;/param&gt;
/// &lt;returns&gt;null, or the given value.&lt;/returns&gt;
private static Nullable&lt;T&gt; ToNullable&lt;T&gt;(
object aValue, Converter&lt;T&gt; aConverter) where T : struct
{
  if (aValue == DBNull.Value || aValue == null)
     return null;
  else if (aValue is T)
     return (T)aValue;
  else
     return aConverter(aValue);
}
</PRE>
