    static public string StackTraceToString()
    {
        StringBuilder sb = new StringBuilder(256);
        var frames = new System.Diagnostics.StackTrace().GetFrames();
        for (int i = 1; i < frames.Length; i++) /* Ignore current StackTraceToString method...*/
        {
            var currFrame = frames[i];
            var method = currFrame.GetMethod();
            sb.AppendLine(string.Format("{0}:{1}",                    
                method.ReflectedType != null ? method.ReflectedType.Name : string.Empty,
                method.Name));
        }
        return sb.ToString();
    }
