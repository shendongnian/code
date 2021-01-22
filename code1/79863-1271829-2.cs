    /// <summary>
        /// Logger processor, which write log to some stream
        /// </summary>
        public class LoggingStream : BaseLogging
        {
            private Stream stream;
    
            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="stream">Initialized stream</param>
            /// <param name="culture">Culture of log system</param>
            public LoggingStream (Stream stream, CultureInfo culture)
                : base(culture)
            {
                this.stream = stream;
            }
    
            /// <summary>
            /// Write message log to stream
            /// </summary>
            /// <param name="str">Message log</param>
            protected override void WriteLine(string str)
            {
                try
                {
                    byte[] bytes;
    
                    bytes = Encoding.ASCII.GetBytes(str + "\n");
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Flush();
                }
                catch { }
            }
    
            /// <summary>
            /// Write Exception to stream
            /// </summary>
            /// <param name="ex">Log's Exception</param>
            protected override void WriteException(Exception ex)
            {
                DateTime dt = DateTime.Now;
    
                string dts = Convert.ToString(dt, culture.DateTimeFormat);
                string message = String.Format("{0} : Exception : {1}", dts, ex.Message);
                if (ex.InnerException != null)
                {
                    message = "Error : " + AddInnerEx(ex.InnerException, message);
                }
                WriteLine(message);
            }
            /// <summary>
            /// Closing stream
            /// </summary>
            public override void Close()
            {
                stream.Close();
            }
    
            private string AddInnerEx(Exception exception, string message)
            {
                message += "\nInner Exception : " + exception.Message;
                if (exception.InnerException != null)
                {
                    message = AddInnerEx(exception.InnerException, message);
                }
                return message;
            }
        }
