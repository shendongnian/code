        public static void WaitForConnectionEx(this NamedPipeServerStream stream, ManualResetEvent cancelEvent)
        {
            Exception e = null;
            AutoResetEvent connectEvent = new AutoResetEvent(false);
            stream.BeginWaitForConnection(ar =>
            {
                try
                {
                    stream.EndWaitForConnection(ar);
                }
                catch (Exception er)
                {
                    e = er;
                }
                connectEvent.Set();
            }, null);
            if (WaitHandle.WaitAny(new WaitHandle[] { connectEvent, cancelEvent }) == 1)
                stream.Close();
            if (e != null)
                throw e; // rethrow exception
        }
