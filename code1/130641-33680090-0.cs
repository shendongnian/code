    	/// <summary>
		/// Removes the first 10 lines from the output.  This removes the junk from the .NET Code Generator.
		/// </summary>
		internal class CodeOutputHelper : TextWriter
		{
			private readonly TextWriter _Inner;
			private int _CountDown = 10;
			public CodeOutputHelper( TextWriter inner )
			{
				_Inner = inner;
			}
			public override void WriteLine(string s)
			{
				if( _CountDown-- <= 0 )
				{
					_Inner.WriteLine(s);
				}
			}
			public override void Write( string value )
			{
				if (_CountDown<=0)
				_Inner.Write( value );
			}
			public override void Write( char value )
			{
				_Inner.Write( value );
			}
			public override Encoding Encoding
			{
				get
				{
					return _Inner.Encoding;
				}
			}
		}
    }
