    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using log4net;
    using log4net.Util;
    using log4net.Layout.Pattern;
    
    using log4net.Core;
    
    using System.Diagnostics;
    
    namespace Log4NetTest
    {
      class LogicalOperationStackPatternConverter : PatternLayoutConverter
      {
        protected override void Convert(System.IO.TextWriter writer, LoggingEvent loggingEvent)
        {
          string los = "";
    
          if (String.IsNullOrWhiteSpace(Option) || String.Compare(Option.Substring(0, 1), "A", true) == 0)
          {
            //Log ALL of stack
            los = Trace.CorrelationManager.LogicalOperationStack.Count > 0 ? 
                    string.Join(">>",Trace.CorrelationManager.LogicalOperationStack.ToArray()) :
                    "";
          }
          else
          if (String.Compare(Option.Substring(0, 1), "T", true) == 0)
          {
            //Log TOP of stack
            los = Trace.CorrelationManager.LogicalOperationStack.Count > 0 ?
                    Trace.CorrelationManager.LogicalOperationStack.Peek().ToString() : "";
          }
    
          writer.Write(los);
        }
      }
    }
