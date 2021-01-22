	using System.Diagnostics;
	using System.IO;
	using System.Text;
	
	namespace TestConsole
	{
		public class DebugTextWriter : TextWriter
		{
			public override Encoding Encoding
			{
				get { return Encoding.UTF8; }
			}
	
			//Required
			public override void Write(char value)
			{
				Debug.Write(value);
			}
	
			//Added for efficiency
			public override void Write(string value)
			{
				Debug.Write(value);
			}
	
			//Added for efficiency
			public override void WriteLine(string value)
			{
				Debug.WriteLine(value);
			}
		}
	}
