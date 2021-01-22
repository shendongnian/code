        protected override void OnSizeChanged(EventArgs e) {
            base.OnSizeChanged(e);
            this.WindowState = FormWindowState.Normal;
            this.Location = SystemInformation.VirtualScreen.Location;
            this.Size = SystemInformation.VirtualScreen.Size;
            this.BringToFront();
        }
