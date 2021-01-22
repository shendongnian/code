    public void DemoCallback()
    {
    	MethodDelegate dlgt = new MethodDelegate (this.LongRunningMethod) ;
    	string s ;
    	int iExecThread;
    
    	// Create the callback delegate.
    	AsyncCallback cb = new AsyncCallback(MyAsyncCallback);
    
    	// Initiate the Asynchronous call passing in the callback delegate
    	// and the delegate object used to initiate the call.
    	IAsyncResult ar = dlgt.BeginInvoke(3000, out iExecThread, cb, dlgt); 
    }
    
    public void MyAsyncCallback(IAsyncResult ar)
    {
    	string s ;
    	int iExecThread ;
    
    	// Because you passed your original delegate in the asyncState parameter
    	// of the Begin call, you can get it back here to complete the call.
    	MethodDelegate dlgt = (MethodDelegate) ar.AsyncState;
    
    	// Complete the call.
    	s = dlgt.EndInvoke (out iExecThread, ar) ;
    
    	MessageBox.Show (string.Format ("The delegate call returned the string:   \"{0}\", 
                                    and the number {1}", s, iExecThread.ToString() ) );
    }
