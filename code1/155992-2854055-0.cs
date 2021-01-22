    class MyTraceListener : TraceListener
    {
        // ...
        public override void Fail(string msg, string detailedMsg)
        {
            // log the message (don't display a MessageBox)
        }
    }
