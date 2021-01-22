    using log4net;
    using log4net.Util;
    using log4net.Layout.Pattern;
    
    using log4net.Core;
    
    using System.Runtime.Remoting.Messaging;
    
    namespace Log4NetTest
    {
      class LogicalCallContextPatternConverter : PatternLayoutConverter
      {
        protected override void Convert(System.IO.TextWriter writer, LoggingEvent loggingEvent)
        {
          string output = "";
          object value = CallContext.LogicalGetData("MyLogicalData");
          if (value == null)
          {
            output = "";
          }
          else
          {
            output = value.ToString();
          }
    
          writer.Write(output);
        }
      }
    }
