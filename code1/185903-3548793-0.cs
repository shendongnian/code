    public static class MissingCompilerFeatures
    {
        public static void SetToNullAndDispose(ref IDisposable obj)
        {
            if (obj != null) { obj.Dispose(); obj = null; }
        }
    }
