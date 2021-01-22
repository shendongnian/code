    public class MyMessageFilter : IMessageFilter
    {
        int IMessageFilter.HandleInComingCall(int dwCallType, IntPtr hTaskCaller,int dwTickCount, IntPtr lpInterfaceInfo)
        {
            // 0 means that it's handled.
            return 0;
        }
    
        int IMessageFilter.RetryRejectedCall(IntPtr hTaskCallee, int dwTickCount, int dwRejectType)
        {
            // The return value is the delay (in ms) before retrying.
            return 1000;
        }
    
        int IMessageFilter.MessagePending(IntPtr hTaskCallee, int dwTickCount, int dwPendingType)
        {
            // 1 hear means that the message is still not processed and to just continue waiting.
            return 1;
        }
    }
