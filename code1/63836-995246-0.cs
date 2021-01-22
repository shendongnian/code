        private void notifyIcon_Click(object sender, EventArgs e)
        {
            var eventArgs = e as MouseEventArgs;
            switch (eventArgs.Button)
            {
                // Left click to reactivate
                case MouseButtons.Left:
                    // Do your stuff
                    break;
            }
        }
