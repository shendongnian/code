        public class ListStringConverter: StringConverter
		{
			public static List<object> Objects = new List<object>();
			public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
			{
				return true;
			}
			public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
			{
				return new StandardValuesCollection(Objects);
			}
		}
