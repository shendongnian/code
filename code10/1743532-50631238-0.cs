    [LayoutRenderer("ignore-exception")]
    public class ExceptionLoggingRenderer : LayoutRenderer
    {
        /// <summary>
        /// What exception was thrown (used to check along with the Code)
        /// </summary>
        [RequiredParameter]
        public Layout Exception { get; set; }
    
        /// <summary>
        /// What error code was thrown (used to check along with the Exception)
        /// </summary>
        [RequiredParameter]
        public string Code { get; set; }
    
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var exceptionString = Exception.Render(logEvent);
        }
    
       
    }
