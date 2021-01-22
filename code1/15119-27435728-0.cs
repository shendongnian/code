    private delegate void xThreadCallBack();
    private void ThreadCallBack()
    {
        if (this.InvokeRequired)
        {
            this.BeginInvoke(new xThreadCallBack(ThreadCallBack));
        }
        else
        {
            //do what you want
        }
    }
