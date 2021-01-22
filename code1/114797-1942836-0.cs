        private event TestEventEventHandler TestEvent;
        private delegate void TestEventEventHandler(EventArgs e);
        private void button1_Click(object sender, EventArgs e)
        {
            TestEvent += TestEventHandler;
            if (TestEvent != null)
            {
                TestEvent(new EventArgs());
            }
        }
        private void TestEventHandler(EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("hi");
        }
