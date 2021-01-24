	static string EncodeNonAsciiCharacters( string value ) {
		StringBuilder sb = new StringBuilder();
		foreach( char c in value ) {
			if( c > 127 ) {
				// This character is too big for ASCII
				string encodedValue = "\\u" + ((int) c).ToString( "x4" );
				sb.Append( encodedValue );
			}
			else {
				sb.Append( c );
			}
		}
		return sb.ToString();
	}
	static string DecodeEncodedNonAsciiCharacters( string value ) {
		return Regex.Replace(
			value,
			@"\\u(?<Value>[a-zA-Z0-9]{4})",
			m => {
				return ((char) int.Parse( m.Groups["Value"].Value, NumberStyles.HexNumber )).ToString();
			} );
	}
