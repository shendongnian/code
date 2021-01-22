    public class MyControl : Control
    {
        internal int suspendCounter = 0;
        internal void SuspendDrawing()
        {
            if(suspendCounter == 0) 
                SendMessage(this.Handle, WM_SETREDRAW, false, 0);
            suspendCounter++;
        }
        internal void ResumeDrawing()
        {
            suspendCounter--; 
            if(suspendCounter == 0) 
            {
                SendMessage(this.Handle, WM_SETREDRAW, true, 0);
                this.Refresh();
            }
        }
    }
