    public class Control //...
    { //...
            public IntPtr Handle
            {
                get
                {
                    if ((checkForIllegalCrossThreadCalls && !inCrossThreadSafeCall) && this.InvokeRequired)
                    {
                        throw new InvalidOperationException(System.Windows.Forms.SR.GetString("IllegalCrossThreadCall", new object[] { this.Name }));
                    }
                    if (!this.IsHandleCreated)
                    {
                        this.CreateHandle();
                    }
                    return this.HandleInternal;
                }
            }
    }
When run in the debugger, checkForIllegalCrossThreadCalls is true, inCrossThreadSafeCall is false, and this.InvokeRequired is true despite being in the UI thread!
Note that Control.InvokeRequired winds up doing this:
int windowThreadProcessId = System.Windows.Forms.SafeNativeMethods.GetWindowThreadProcessId(ref2, out num);
int currentThreadId = System.Windows.Forms.SafeNativeMethods.GetCurrentThreadId();
return (windowThreadProcessId != currentThreadId);
