        bool lastNotificationWasGotFocus = false;
        protected override void OnControlAdded(ControlEventArgs e)
        {
            SubscribeEvents(e.Control);
            base.OnControlAdded(e);
        }
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            UnsubscribeEvents(e.Control);
            base.OnControlRemoved(e);
        }
        private void SubscribeEvents(Control control)
        {
            control.GotFocus += new EventHandler(control_GotFocus);
            control.LostFocus += new EventHandler(control_LostFocus);
            control.ControlAdded += new ControlEventHandler(control_ControlAdded);
            control.ControlRemoved += new ControlEventHandler(control_ControlRemoved);
            foreach (Control innerControl in control.Controls)
            {
                SubscribeEvents(innerControl);
            }
        }
        private void UnsubscribeEvents(Control control)
        {
            control.GotFocus -= new EventHandler(control_GotFocus);
            control.LostFocus -= new EventHandler(control_LostFocus);
            control.ControlAdded -= new ControlEventHandler(control_ControlAdded);
            control.ControlRemoved -= new ControlEventHandler(control_ControlRemoved);
            foreach (Control innerControl in control.Controls)
            {
                UnsubscribeEvents(innerControl);
            }
        }
        private void control_ControlAdded(object sender, ControlEventArgs e)
        {
            SubscribeEvents(e.Control);
        }
        private void control_ControlRemoved(object sender, ControlEventArgs e)
        {
            UnsubscribeEvents(e.Control);
        }
        protected override void OnGotFocus(EventArgs e)
        {
            CheckContainsFocus();
            base.OnGotFocus(e);
        }
        protected override void OnLostFocus(EventArgs e)
        {
            CheckLostFocus();
            base.OnLostFocus(e);
        }
        private void control_GotFocus(object sender, EventArgs e)
        {
            CheckContainsFocus();
        }
        private void control_LostFocus(object sender, EventArgs e)
        {
            CheckLostFocus();
        }
        private void CheckContainsFocus()
        {
            if (lastNotificationWasGotFocus == false)
            {
                lastNotificationWasGotFocus = true;
                OnContainsFocus();
            }
        }
        private void CheckLostFocus()
        {
            if (ContainsFocus == false)
            {
                lastNotificationWasGotFocus = false;
                OnLostFocus();
            }
        }
        private void OnContainsFocus()
        {
            Console.WriteLine("I have the power of focus!");
        }
        private void OnLostFocus()
        {
            Console.WriteLine("I lost my power...");
        }
