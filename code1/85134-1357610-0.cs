    class MyTraceListener : TraceListener
    {
            private RichTextBox output;
    
            public MyTraceListener (RichTextBox output) {
                    this.Name = "DebugTrace";
                    this.output = output;
            }
    
    
            public override void Write(string message) {
                    Action append = delegate() { output.AppendText(message); };
                    if (output.InvokeRequired) {
                            output.Invoke(append);
                    } else {
                            append();
                    }
            }
    
            public override void WriteLine(string message) {
                    Action append = delegate() { output.AppendText(message + "\r\n"); };
                    if (output.InvokeRequired) {
                            output.Invoke(append);
                    } else {
                            append();
                    }
    
            }
    }
