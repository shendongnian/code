	using System;
	using Newtonsoft.Json;
	[JsonConverter(typeof(ConstantConverter))]
	public class StringEnum: IConvertible
	{
		public string Value { get; set; }
		protected StringEnum(string value)
		{
			Value = value;
		}
		public static implicit operator string(StringEnum c)
		{
			return c.Value;
		}
		public string ToString(IFormatProvider provider)
		{
			return Value;
		}
		public TypeCode GetTypeCode()
		{
			throw new NotImplementedException();
		}
		public bool ToBoolean(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}
		//The same for all the rest of IConvertible methods
	}
