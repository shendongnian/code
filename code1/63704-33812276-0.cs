    static class IOExceptionExtensions
    {
        public static int GetHResult(this IOException ex)
        {
            var info = new SerializationInfo(typeof (IOException), new FormatterConverter());
            ex.GetObjectData(info, new StreamingContext());
            return info.GetInt32("HResult");
        }
    }
