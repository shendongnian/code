    public class YourClass
    {
        private static Dictionary<int, string> characterLookup;
        private static ManualResetEvent lookupCreated;
        static YourClass()
        {
            lookupCreated = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem(LoadLookup);
        }
        static void LoadLookup(object garbage)
        {
            // add your pairs by calling characterLookup.Add(...)
            lookupCreated.Set();
        }
        public static string GetDescription(int code)
        {
            if (lookupCreated != null)
            {
                lookupCreated.WaitOne();
                lookupCreated.Close();
                lookupCreated = null;
            }
            string output;
            if(!characterLookup.TryGetValue(code, out output)) output = null;
            return output;
        }
    }
