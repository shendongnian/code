	public class Base : ICloneable
	{
		public virtual object Clone()
		{
			return new Base();
		}
	}
	
	public class Derived : Base
	{
		public override object Clone()
		{
			return new Derived();
		}
	}
	
	public static T Copy<T>(this T obj) where T : class, ICloneable
	{
		return obj.Clone() as T;
	}
