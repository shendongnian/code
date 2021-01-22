    System.Windows.Forms.MethodInvoker mi = new System.Windows.Forms.MethodInvoker(delegate()
    {
        // Do your file copy here
    });
    
    AsyncCallback ascb = new AsyncCallback(delegate(IAsyncResult ar)
    {
        this.Dispatcher.Invoke(new ThreadStart(delegate (){
        // set progressbar value to 100 here
        }), null);
    });
    
    mi.BeginInvoke(ascb, null);
