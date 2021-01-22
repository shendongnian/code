    public class TextHelper : TextWriter
        {
            TextWriter console;
    
            public TextHelper() {
                console = Console.Out;
            }
    
            public override Encoding Encoding { get { return this.console.Encoding; } }
            public override void WriteLine(string format, params object[] arg)
            {
                string s = string.Format(format, arg);
                WriteLine(s);
            }
            public override void Write(object value)
            {
                console.Write(value);
                System.Diagnostics.Trace.Write(value);
            }
    
            public override void WriteLine(object value)
            {
                Write(value);
                Write("\n");
            }
            public override void WriteLine(string value)
            {
                console.WriteLine(value);
                System.Diagnostics.Trace.WriteLine(value);
    
            }
      
        }
