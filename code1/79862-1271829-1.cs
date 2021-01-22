    public abstract class BaseLogging
        {
            /// <summary>
            /// Culture (using for date) 
            /// </summary>
            public CultureInfo culture;
    
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="culture">Culture</param>
            public BaseLogging(CultureInfo culture)
            {
                this.culture = culture;
            }
    
            /// <summary>
            /// Add log in log system
            /// </summary>
            /// <param name="str">message of log</param>
            public virtual void AddLogs(string str)
            {
                DateTime dt = DateTime.Now;
    
                string dts = Convert.ToString(dt, culture.DateTimeFormat);
    
                WriteLine(String.Format("{0} : {1}", dts, str));
            }
    
            /// <summary>
            /// Add log in log system
            /// </summary>
            /// <param name="ex">Exception</param>
            public virtual void AddLogs(Exception ex)
            {
                DateTime dt = DateTime.Now;
    
                string dts = Convert.ToString(dt, culture.DateTimeFormat);
                WriteException(ex);
            }
    
            /// <summary>
            /// Write string on log system processor 
            /// </summary>
            /// <param name="str">logs message</param>
            protected abstract void WriteLine(string str);
    
            /// <summary>
            /// Write string on log system processor 
            /// </summary>
            /// <param name="ex">Exception</param>
            protected abstract void WriteException(Exception ex);
    
            /// <summary>
            /// Close log system (file, stream, etc...)
            /// </summary>
            public abstract void Close();
        }
