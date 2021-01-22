    using System;
    
    namespace System.Windows.Forms
    {
        // Summary:
        //     Provides methods for sending keystrokes to an application.
        public class SendKeys
        {
            // Summary:
            //     Processes all the Windows messages currently in the message queue.
            public static void Flush();
            //
            // Summary:
            //     Sends keystrokes to the active application.
            //
            // Parameters:
            //   keys:
            //     The string of keystrokes to send.
            //
            // Exceptions:
            //   System.InvalidOperationException:
            //     There is not an active application to send keystrokes to.
            //
            //   System.ArgumentException:
            //     keys does not represent valid keystrokes
            public static void Send(string keys);
            //
            // Summary:
            //     Sends the given keys to the active application, and then waits for the messages
            //     to be processed.
            //
            // Parameters:
            //   keys:
            //     The string of keystrokes to send.
            public static void SendWait(string keys);
        }
    }
