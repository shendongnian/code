    static class SafeInvoker
    {
        //Utility to avoid boiler-plate InvokeRequired code
        //Usage: myCtrl.SafeInvoke(() => myCtrl.Enabled = false);
        public static void SafeInvoke(this Control ctrl, Action cmd)
        {
            if (ctrl.InvokeRequired)
                ctrl.BeginInvoke(cmd);
            else
                cmd();
        }
        //Replaces OnMyEventRaised boiler-plate code
        //Usage: this.RaiseEvent(myEventRaised);
        public static void RaiseEvent(this object sender, EventHandler evnt)
        {
            var temp = evnt;
            if (temp != null)
                temp(sender, EventArgs.Empty);
        }
    }
