        public override void WriteLine(object o, string category)
        {
            // hack to prevent log4nets own diagnostic trace getting fed back
            var method = GetTracingStackFrame(new StackTrace()).GetMethod();
            var declaringType = method.DeclaringType;
            if (declaringType == typeof(LogLog))
            {
                return;
            }
            /* rest of method writes to log4net */
        }
