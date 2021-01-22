public static void ChangeProperty&lt;T>(this object obj, string propertyName, Func&lt;T,T> func)
{
	var pi = obj.GetType().GetProperty(propertyName);
	pi.SetValue(obj, func((T)pi.GetValue(obj, null)), null);
}
public void Change()
{
	thisColor.ChangeProperty&lt;int>("R", (x) => x + 5);
}
