	public class BaseType()
	{
		public static Constant<BaseType, string> Description { get; private set; }
		
		static BaseType()
		{
			Description = new BaseTypeDescription();
		}
	}
	public class DerivedType() : BaseType()
	{ }
	internal sealed class BaseTypeDescription() : Constant<BaseType, string>
	{
		public BaseTypeDescription() : base()
		{ }
		
		protected override Initialize()
		{
			RegisterConstant<BaseType>("A base type");
			RegisterConstant<DerivedType>("A derived type");
		}
	}
