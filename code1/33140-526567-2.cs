	static class Program {
		static void Main() {
			var xmlDecimal = new XElement( "decimal" );
			xmlDecimal.Value = ( 123.456m ).ToString();
			decimal valueOfDecimal_1 = xmlDecimal.ValueAs<decimal>( decimal.TryParse );
			bool valueOfBool_1 = xmlDecimal.ValueAs<bool>( bool.TryParse );
			var xmlBool = new XElement( "bool" );
			xmlBool.Value = true.ToString();
			decimal valueOfDecimal_2 = xmlBool.ValueAs<decimal>( decimal.TryParse );
			bool valueOfBool_2 = xmlBool.ValueAs<bool>( bool.TryParse );
		}
	}
	public static class StaticClass {
		public delegate bool TryParseDelegate<T>( string text, out T value );
		public static T ValueAs<T>( this XElement element, TryParseDelegate<T> parseDelegate ) {
			return ValueAs<T>( element, parseDelegate, default( T ) );
		}
		public static T ValueAs<T>( this XElement element, TryParseDelegate<T> parseDelegate, T defaultValue ) {
			if ( null == element ) { return defaultValue; }
			T result;
			bool ok = parseDelegate( element.Value, out result );
			if ( ok ) { return result; }
			return defaultValue;
		}
	}
