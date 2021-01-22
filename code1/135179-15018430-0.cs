    public static class GenericParser {
		public static T Parse<T>(this string input) {
			var converter = TypeDescriptor.GetConverter(typeof(T));
			if ( converter != null ) {
				return ( T )converter.ConvertFromString(input);
			}
			return default(T);
		}
	}    
