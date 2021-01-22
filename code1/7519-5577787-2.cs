	using System.IO;
	using System.Runtime.InteropServices;
	using System.Text;
	
	namespace TestConsole
	{
		public class OutputDebugStringTextWriter : TextWriter
		{
			[DllImport("kernel32.dll")]
			static extern void OutputDebugString(string lpOutputString);
	
			public override Encoding Encoding
			{
				get { return Encoding.UTF8; }
			}
	
			//Required
			public override void Write(char value)
			{
				OutputDebugString(value.ToString());
			}
	
			//Added for efficiency
			public override void Write(string value)
			{
				OutputDebugString(value);
			}
	
			//Added for efficiency
			public override void WriteLine(string value)
			{
				OutputDebugString(value);
			}
		}
	}
