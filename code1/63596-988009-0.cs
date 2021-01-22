public static T GetPropertyValue&lt;T&gt;(object o, string propertyName)
{
      return (T)o.GetType().GetProperty(propertyName).GetValue(o, null);
}
...somewhere else in your code...
GetPropertyValue&lt;string&gt;(f, "Bar");
