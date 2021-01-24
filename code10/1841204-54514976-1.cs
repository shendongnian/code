    public class UpdateRecords
    {
        private static string SleepAndWake()
        {
            System.Threading.Thread.Sleep(1000);
            return "Records updated => async";
        }
        private delegate string SleepAndWakeRecords();
        private class RecordsState
        {
            public readonly SleepAndWakeRecords AsyncDelegate = new SleepAndWakeRecords(SleepAndWake);
        }
        public IAsyncResult BeginUpdateRecords(AsyncCallback cb, object s)
        {
            var state = new RecordsState();
            return state.AsyncDelegate.BeginInvoke(cb, state);
        }
        public static string EndUpdateRecords(IAsyncResult result)
        {
            var returnDelegate = (RecordsState)result.AsyncState;
            return returnDelegate.AsyncDelegate.EndInvoke(result);
        }
    }
