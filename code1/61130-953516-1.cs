    // <summary>
    /// System hotkey interceptor
    /// </summary>
    public class MessageIntercept: IDisposable
    {
        private delegate void MessageEventHandler(object Sender, ref System.Windows.Forms.Message msg, ref bool Handled);
        
        //Window for WM_MYMESSAGE Interceptor
        private DummyWindowWithEvent frmDummyReceiver_m;
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public MessageIntercept()
        {
            this.frmDummyReceiver_m = new DummyWindowWithEvent();
            this.frmDummyReceiver_m.ProcessMessage += new MessageEventHandler(this.InterceptMessage);
        }
    
        private void InterceptMessage(object Sender, ref System.Windows.Forms.Message msg, ref bool Handled)
        {
            //Do something based on criteria of the message
            if ((msg.Msg == (int)WM_MYMESSAGE) && 
                (msg.WParam == (IntPtr)xyz))
            {
                Handled = true;
                System.Diagnostics.Debug.WriteLine("Message intercepted.");
            }
        }
    }
