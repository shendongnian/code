    using System.Runtime.InteropServices;
        
    //provide a private internal message id
    private UInt32 queryCancelAutoPlay = 0;
    
    [DllImport("user32.dll", SetLastError=true, CharSet=CharSet.Auto)]
    static extern uint RegisterWindowMessage(string lpString);
    
    /* only needed if your application is using a dialog box and needs to 
    * respond to a "QueryCancelAutoPlay" message, it cannot simply return TRUE or FALSE.
    [DllImport("user32.dll")]
    static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
    */
    
    protected override void WndProc(ref Message m)
    {
        //calling the base first is important, otherwise the values you set later will be lost
        base.WndProc (ref m);
    
        //if the QueryCancelAutoPlay message id has not been registered...
        if (queryCancelAutoPlay == 0)
            queryCancelAutoPlay = RegisterWindowMessage("QueryCancelAutoPlay");
    
        //if the window message id equals the QueryCancelAutoPlay message id
        if ((UInt32)m.Msg == queryCancelAutoPlay)
        {
            /* only needed if your application is using a dialog box and needs to
            * respond to a "QueryCancelAutoPlay" message, it cannot simply return TRUE or FALSE.
            SetWindowLong(this.Handle, 0, 1);
            */
            m.Result = (IntPtr)1;
        }
    } //WndProc
