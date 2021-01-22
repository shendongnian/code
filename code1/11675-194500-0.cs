        private void StopRepaint()
        {
            // Stop redrawing:
            SendMessage(this.Handle, WM_SETREDRAW, 0, IntPtr.Zero);
            // Stop sending of events:
            eventMask = SendMessage(this.Handle, EM_GETEVENTMASK, 0, IntPtr.Zero);
        }
        private void StartRepaint()
        {
            // turn on events
            SendMessage(this.Handle, EM_SETEVENTMASK, 0, eventMask);
            // turn on redrawing
            SendMessage(this.Handle, WM_SETREDRAW, 1, IntPtr.Zero);
            // this forces a repaint, which for some reason is necessary in some cases.
            this.Invalidate();
        }
