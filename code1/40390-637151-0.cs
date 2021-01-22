    // Add this class somewhere in your project...
    class DebugTextWriter : System.IO.TextWriter {
       public override void Write(char[] buffer, int index, int count) {
           System.Diagnostics.Debug.Write(new String(buffer, index, count));
       }
    
       public override void Write(string value) {
           System.Diagnostics.Debug.Write(value);
       }
    
       public override Encoding Encoding {
           get { return System.Text.Encoding.Default; }
       }
    }
    // Then attach it to the Log property of your DataContext...
    myDataContext.Log = new DebugTextWriter()
