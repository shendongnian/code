    public class SmartLock
    {
        private object LockObject = new object();
        private string HoldingTrace = "";
        private static int WARN_TIMEOUT_MS = 5000; //5 secs
        public void Lock(Action action)
        {
            try
            {
                Enter();
                action.Invoke();
            }
            catch (Exception ex)
            {
                Globals.Error("SmartLock Lock action", ex);
            }
            finally
            {
                Exit();
            }
        }
        private void Enter()
        {
            try
            {
                bool locked = false;
                int timeoutMS = 0;
                while (!locked)
                {
                    //keep trying to get the lock, and warn if not accessible after timeout
                    locked = Monitor.TryEnter(LockObject, WARN_TIMEOUT_MS);
                    if (!locked)
                    {
                        timeoutMS += WARN_TIMEOUT_MS;
                        Globals.Warn("Lock held: " + (timeoutMS / 1000) + " secs by " + HoldingTrace + " requested by " + GetStackTrace());
                    }
                }
                //save a stack trace for the code that is holding the lock
                HoldingTrace = GetStackTrace();
            }
            catch (Exception ex)
            {
                Globals.Error("SmartLock Enter", ex);
            }
        }
        private string GetStackTrace()
        {
            StackTrace trace = new StackTrace();
            string threadID = Thread.CurrentThread.Name ?? "";
            return "[" + threadID + "]" + trace.ToString().Replace('\n', '|').Replace("\r", "");
        }
        private void Exit()
        {
            try
            {
                Monitor.Exit(LockObject);
                HoldingTrace = "";
            }
            catch (Exception ex)
            {
                Globals.Error("SmartLock Exit", ex);
            }
        }
    }
