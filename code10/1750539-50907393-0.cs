    private void doneReadFile(IAsyncResult ar)
    {
        var ctl = ar.AsyncState as System.Windows.Forms.Control; // the control
        if (ctl != null && ctl.InvokeRequired) { // is Invoke needed?
		    // call this method again, but now on the UI thread.
            ctl.Invoke(new Action<IAsyncResult>(doneReadFile), ar);
        } else {
           Bind();
        }
    }
