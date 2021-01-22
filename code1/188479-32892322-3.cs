    [AttributeUsage(AttributeTargets.Property,AllowMultiple = true)]
	public class DependsOnPropertyAttribute : Attribute
	{
		public readonly string Dependence;
		public DependsOnPropertyAttribute(string otherProperty)
		{
			Dependence = otherProperty;
		}
	}
