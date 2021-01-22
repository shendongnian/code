    public class MyControl : Control
    {
        private int suspendCounter = 0;
        private void SuspendDrawing()
        {
            if(suspendCounter == 0) 
                SendMessage(this.Handle, WM_SETREDRAW, false, 0);
            suspendCounter++;
        }
        private void ResumeDrawing()
        {
            suspendCounter--; 
            if(suspendCounter == 0) 
            {
                SendMessage(this.Handle, WM_SETREDRAW, true, 0);
                this.Refresh();
            }
        }
    }
