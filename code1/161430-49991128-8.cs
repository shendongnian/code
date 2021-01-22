        private string GetProblemId(Exception exception)
        {
            var fullName = exception.GetType().FullName;
            var frames = new StackTrace(exception, true)
                .GetFrames();
            if (frames == null)
            {
                return fullName;
            }
            var firstAllowedStackLine = frames
                .Where(frame => !frame.GetMethod().IsDefined(typeof(DebuggerHiddenAttribute), true))
                .Select(frame => new StackTrace(frame).ToString())
                .FirstOrDefault();
            return fullName + firstAllowedStackLine;
        }
