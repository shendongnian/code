    //Dummy window classes.  Because we don't have access to the wndproc method of a form, we create
    //dummy forms and expose the method to the SystemHotKeyHook class as an event.
    
    /// <summary>
    /// Inherits from System.Windows.Form.NativeWindow. Provides an Event for Message handling
    /// </summary>
    private class NativeWindowWithEvent : System.Windows.Forms.NativeWindow
    {
        public event MessageEventHandler ProcessMessage;
        protected override void WndProc(ref Message m)
        {
            //Intercept the message you are looking for...
            if (m.Msg == (int)WM_MYMESSAGE)
            {
                //Fire event which is consumed by your class
                if (ProcessMessage != null)
                {
                    bool Handled = false;
                    ProcessMessage(this, ref m, ref Handled);
                    if (!Handled)
                    {
                        base.WndProc(ref m);
                    }
                }
                else
                {
                    base.WndProc(ref m);
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
    /// <summary>
    /// Inherits from NativeWindowWithEvent and automatic creates/destroys of a dummy window
    /// </summary>
    private class DummyWindowWithEvent : NativeWindowWithEvent, IDisposable
    {
        public DummyWindowWithEvent()
        {
            CreateParams parms = new CreateParams();
            this.CreateHandle(parms);
        }
        public void Dispose()
        {
            if (this.Handle != (IntPtr)0)
            {
                this.DestroyHandle();
            }
        }
    }
