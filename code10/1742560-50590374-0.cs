    public class MyClass
    {
        private static readonly MyLogger.ILog Log = MyLogger.LogManager.GetLogger(typeof(MyClass));
        private void DoSomethingLogged()
        {
            var Log = MyLogger.LogManager.GetLogger(MyClass.Log.Name+"::"+nameof(DoSomethingLogged));
            var localLog = Log;
            var staticLog = MyClass.Log;
            Log.Info("method called");
        }
    }
