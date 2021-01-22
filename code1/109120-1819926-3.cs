class CanUsbSafeHandle : SafeHandle
{
    private EventHandler _receiveCallBack;
    private readonly object _receiveCallBackLock = new object();
    public event EventHandler ReceiveCallBack
    {
        add
        {
            lock (_receiveCallBackLock)
            {
                bool hasListeners = (_receiveCallBack != null);
                _receiveCallBack += value;
                //call canusb_setReceiveCallBack only when 1 or more listeners were added
                //and there were previously no listeners
                if (!hasListeners && (_receiveCallBack != null))
                {
                    canusb_setReceiveCallBack(this, setCallBack);
                }
            }
        }
        remove
        {
            lock (_receiveCallBackLock)
            {
                bool hasListeners = (_receiveCallBack != null);
                _receiveCallBack -= value;
                //call canusb_setReceiveCallBack only when there are no more listeners.
                if(hasListeners && (_receiveCallBack == null))
                {
                    canusb_setReceiveCallBack(this, null);
                }
            }
        }
    }
    public CanUsbSafeHandle()
        : base(IntPtr.Zero, true)
    {
    }
    public override bool IsInvalid
    {
        get { return handle == IntPtr.Zero; }
    }
    protected override bool ReleaseHandle()
    {
        return canusb_Close(handle);
    }
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            lock (_receiveCallBackLock)
            {
                _receiveCallBack = null;
            }
        }
        base.Dispose(disposing);
    }
}
