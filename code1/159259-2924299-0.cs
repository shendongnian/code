        public ImageDisplay()
        {
            Trace.Listeners.Add(new TextWriterTraceListener(@"c:\happyface.trace.log"));
            Trace.AutoFlush = true;
            InitializeComponent();
            Trace.WriteLine(String.Format("Image thinks it's in {0}", displayImage.Source.ToString()));
        }
