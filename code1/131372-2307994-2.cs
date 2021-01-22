    private AutoResetEvent myResetEvent;
    private void MyCallFunction(object someParameter) {
        
        if (this.Dispatcher.CheckAccess())
        {
            Action<object> a = new Action<object>(MyCallFunction);
            a.BeginInvoke(someParameter, null, null);
            return;
        }
        myResetEvent = new AutoresetEvent();
        myAsyncCall.CallCompleted += new EventHandler<>(myAsyncCall_CallCompleted);
        myAsyncCall.DoAsyncCall(someParameter);
        myResetEvent.WaitOne();
        //increment your count here
    }
    private void myAsyncCall_CallCompleted(object sender, SomeEventArgs e) {
        if (e.Error == null && !e.Cancelled) {
            if (myResetEvent != null)
                myResetEvent.Set();
        }
    }
