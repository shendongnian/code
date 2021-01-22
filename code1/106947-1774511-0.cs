IEnumerable&lt;PropertyInfo&gt; GetProperties(Type t, int depth)
{
  List&lt;PropertyInfo&gt; properties = new List&lt;PropertyInfo&gt;();
  if (type != null)
  {
    while (depth-- > 0)
    {
      properties.AddRange(type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance) ;
    }
  }
  return properties;
}
