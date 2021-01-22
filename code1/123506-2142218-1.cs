    delegate int NotifyDelegate(INSSBuffer3 pNSSBuffer3, IPin pPin, long prtStart, long prtEnd);
    
    void run(){
      bufferPassCallbackInterface = new IAMWMBufferPassCallbackImpl(this);
      IAMWMBufferPass bPass = (IAMWMBufferPass)DSHelper.GetPin(pWMASFWriter, "Video Input 01");
      NotifyDelegate d = new NotifyDelegate(bufferPassCallbackInterface.Notify);
      hr = bPass.SetNotify(d);
      DsError.ThrowExceptionForHR(hr);  
    }
