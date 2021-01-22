    [ConfigurationElementType(typeof(CustomTraceListenerData))]
    public class CustomListener: CustomTraceListener
    {
		#region Fields (3) 
        private int logSize;
        StreamWriter sw;
		#endregion Fields 
		#region Constructors (1) 
        public CustomListener ():base()
        {
            string startPath = this.buildCurrPath();
            sw = new StreamWriter(startPath + "\\Logs\\test.log");
            sw.AutoFlush = true;
        }
