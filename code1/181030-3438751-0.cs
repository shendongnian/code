System.Diagnostics.Trace.WriteLine() is your friend.  You can then create a subclass of System.Diagnostics.TraceListener and register it by adding it to  System.Diagnostics.Trace.TraceListeners so that your code receives notification of these events.
Note that the trace events will only be compiled into the code when the TRACE conditional compilation flag is set (usually by adding it to the 'Conditional Compilation Symbols' box in each relevant project's settings).
----
public sealed class MyTraceListener : TraceListener
{
    public MyTraceListener() : base("MyTraceListener")
    {
    }
    public override void Write(string message)
    {
        //TODO code here to add to your UI element
        //NOTE make sure you hand off to the UI thread e.g.
        //     using InvokeRequired/Invoke
    }
}
