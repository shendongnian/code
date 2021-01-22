        private void toggleControls(Control control, bool state)
        {
            foreach (Control c in control.Controls)
            {
                c.Enabled = state;
                if (c is Control)
                {
                    toggleControls(c, state);
                }
            }
        }
