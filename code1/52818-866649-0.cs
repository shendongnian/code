    [Export("/MyViewModel")]
    public class MyViewModel
    {
        [ImportingConstructor]
        public MyViewModel(
            [Import("/Services/LoggingService")] ILoggingService l)
        {
            logger = l;
        }
        private ILoggingService logger { get; set; }
        /* ... */
    }
