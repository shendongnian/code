            private void DisableButtons()
        {
            foreach (var ctl in Controls.OfType<Button>())
            {
                ctl.Enabled = false;
            }
        }
        private void EnableButtons()
        {
            foreach (var ctl in Controls.OfType<Button>())
            {
                ctl.Enabled = true;
            }
        }
