        static void PreserveStackTrace(Exception e)
        {
            var ctx = new StreamingContext(StreamingContextStates.CrossAppDomain);
            var si = new SerializationInfo(typeof(Exception), new FormatterConverter());
            var ctor = typeof(Exception).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(SerializationInfo), typeof(StreamingContext) }, null);
            e.GetObjectData(si, ctx);
            ctor.Invoke(e, new object[] { si, ctx });
        }
