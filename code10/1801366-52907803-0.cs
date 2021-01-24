    class Program
    {
        static void Main(string[] args)
        {
            var listener = new TestTraceListener();
            Trace.Listeners.Add(listener);
            Trace.WriteLine("Test");
            listener.Dispose();
            Trace.WriteLine("After dispose");
        }
    }
    public class TestTraceListener : TraceListener
    {
        public override void Write(string message)
        {
            File.AppendAllText("log.log", message);
        }
        public override void WriteLine(string message)
        {
            this.Write(message + Environment.NewLine);
        }
        protected override void Dispose(bool disposing)
        {
            this.WriteLine("Dispose called");
            base.Dispose(disposing);
        }
        ~TestTraceListener()
        {
            this.WriteLine("Destructor called");
        }
    }
