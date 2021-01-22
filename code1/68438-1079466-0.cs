    bool IsPresent(BluetoothAddress addr) // address from config somehow
    {
       BluetoothDeviceInfo bdi = new BluetoothDeviceInfo(addr);
       if (bdi.Connected) {
          return true;
       }
       Guid arbitraryClass = BluetoothService.Headset;
       AsyncResult<bool> ourAr = new AsyncResult<bool>(); // Jeffrey Richter's impl
       IAsyncResult ar = bdi.BeginGetService(arbitraryClass, IsPresent_GsrCallback, ourAr);
       bool signalled = ourAr.AsyncWaitHandle.WaitOne(Timeout);
       if (!signalled) {
          return false; // Taken too long, so not in range
       } else {
          return ourAr.Result;
       }
    }
    void IsPresent_GsrCallback(IAsyncResult ar)
    {
        AsyncResult<bool> ourAr = (AsyncResult<bool>)ar.AsyncState;
        const bool IsInRange = true;
        try {
           bdi.EndGetServiceResult(ar);
           ourAr.SetAsCompleted(IsInRange, false);
        } catch {
           // If this returns quickly, then it is in range and
           // if slowly then out of range but caller will have
           // moved on by then... So set true in both cases...
           // TODO check what error codes we get here. SocketException(10108) iirc
           ourAr.SetAsCompleted(IsInrange, false);
        }
    }
