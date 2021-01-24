    public class FileAppenderX2 : AppenderSkeleton
    {
        private FileAppender _output1;
        private FileAppender _output2;
        public string Output1 { get; set; }
        public string Output2 { get; set; }
        public override void ActivateOptions()
        {
            base.ActivateOptions();
            _output1 = new FileAppender() { Layout = this.Layout, File = Output1 };
            _output2 = new FileAppender() { Layout = this.Layout, File = Output2 };
            _output1.ActivateOptions();
            _output2.ActivateOptions();
        }
        public FileAppenderX2()
        {
        }
        protected override void Append(LoggingEvent loggingEvent)
        {
            _output1.DoAppend(loggingEvent);
            _output2.DoAppend(loggingEvent);
        }
    }
