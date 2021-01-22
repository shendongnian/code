    public static class Logger
    {
        public static void Write(IActivity activity)
        {
            // Ask activity for its data and write it down to a log file
            WriteToFile(activity.Log());
        }
    
        public static void Write(Func<string> action)
        {
            Write(new ActivityEntry(action));
        }
    }
