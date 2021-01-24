    namespace System.Windows.Forms
    {
        public class SendKeys
        {
            //
            // Summary:
            //     Processes all the Windows messages currently in the message queue.
            public static void Flush();
            
            public static void Send(string keys);
            
            public static void SendWait(string keys);
        }
    }
