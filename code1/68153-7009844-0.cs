    while (!_stopReceivingEvents) {
        IntPtr eventHandle;
        var hr = _mediaEvent.GetEventHandle(out eventHandle);
        DsError.ThrowExceptionForHR(hr);
        //NOTE: Do not close the event handle, because it is used internally by the filter graph
        using (var safeWaitHandle = new SafeWaitHandle(eventHandle, false)) {
            using (var waitHandle = new AutoResetEvent(false) {SafeWaitHandle = safeWaitHandle}) {
                if (WaitHandle.WaitAll(new[] {waitHandle}, 500)) {
                    //receive all available events
                    do {
                        EventCode eventCode;
                        IntPtr param1;
                        IntPtr param2;
                        hr = _mediaEvent.GetEvent(out eventCode, out param1, out param2, 500);
                        _mediaEvent.FreeEventParams(eventCode, param1, param2);
                        if (hr == 0) {
                            switch (eventCode) {
                                //add handling code here
                            }
                        }
                    } while (hr == 0);
                }
            }
        }
    }
