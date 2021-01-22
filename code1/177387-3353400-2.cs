    public class MyComponent
    {
        public void EntryPoint()
        {
            MyLogger.CurrentLoggerThreadName = "A thread contextual name.";
            _myLogger.Info("a logging message.");
            SomeOtherMethod();
        }
        private void SomeOtherMethod()
        {
            _myLogger.Info("another logging message with the same thread name.");
        }
    }
    public class MyLogger
    {
        [ThreadStatic]
        private static string _CurrentLoggerThreadName;
        private static readonly FieldInfo NameField = typeof(Thread).GetType().GetField("m_Name", BindingFlags.Instance | BindingFlags.NonPublic);
        public static string CurrentLoggerThreadName
        {
            get { return _CurrentLoggerThreadName; }
            set { _CurrentLoggerThreadName = value; }
        }
        private static void LogWithThreadRename(Action loggerAction)
        {
            Thread t1 = Thread.CurrentThread;
            string originalName = (string)NameField.GetValue(t1);
            try
            {
                NameField.SetValue(t1, CurrentLoggerThreadName);
                loggerAction();
            }
            finally
            {
                NameField.SetValue(t1, originalName);
            }
        }
        public void Info(object message)
        {
            LogWithThreadRename(() => _iLog.Info(message));
        }
        //More logging methods...
    }
