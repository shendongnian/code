    using System;
    using System.Diagnostics;
    using NUnit.Framework;
    [SetUpFixture]
    public class NUnitSetup
    {
        // Field to hold exisitng trace listeners so they can be restored after test are run.
        private TraceListener[] originalListeners = null;
        // A trace listener to use during testing.
        private TraceListener nunitListener = new NUnitListener();
        [SetUp]
        public void SetUp()
        {
            // Replace existing listeners with listener for testing.
            this.originalListeners = new TraceListener[Trace.Listeners.Count];
            Trace.Listeners.CopyTo(this.originalListeners, 0);
            Trace.Listeners.Clear();
            Trace.Listeners.Add(this.nunitListener);
        }
        [TearDown]
        public void TearDown()
        {
            // Restore original trace listeners.
            Trace.Listeners.Remove(this.nunitListener);
            Trace.Listeners.AddRange(this.originalListeners);
        }
        
        public class NUnitListener : DefaultTraceListener
        {
            public override void Fail(string message)
            {
                Console.WriteLine("Ignoring Debug.Fail(\"{0}\")", message);
            }
            public override void Fail(string message, string detailMessage)
            {
                Console.WriteLine("Ignoring Debug.Fail(\"{0},{1}\")", message, detailMessage);
            }
        }
    }
