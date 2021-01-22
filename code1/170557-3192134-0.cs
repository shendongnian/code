    using System; using System.Collections.Generic; using System.Linq; using System.Web;using log4net; using log4net.Config; using log4net.Core;using log4net.Layout; using System.Text; using System.IO; using log4net.Layout.Pattern; namespace myWebApplication {
    public sealed class HexPatternConverter : PatternLayoutConverter
    {
        override protected void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            long id;
            if (long.TryParse(loggingEvent.ThreadName, out id))
            {
                writer.Write(id.ToString("X"));
            }
            else
            {
                writer.Write(loggingEvent.ThreadName);
            }
        }
    }
    public class myClass
    {
        private static readonly ILog secondlog = LogManager.GetLogger("methodB");
        private static readonly ILog thirdlog = LogManager.GetLogger("methodC");
        private static readonly ILog fourthlog = LogManager.GetLogger("methodD");
        private static readonly ILog fifthlog = LogManager.GetLogger("ADONetAppender");
        public static int methodA()
        {
            int a = 0;
            return a;
        }
        public static void methodB()
        {
            methodA();
            secondlog.Info("inside method B");
        }
        public static void methodC()
        {
            methodB();
            thirdlog.Info("inside method C");
        }
        public static void methodD()
        {
            methodC();
            fourthlog.Info("inside D");
            fifthlog.Info("this is db log");
            fifthlog.Info("this is me logging to the db");
        }
    }
