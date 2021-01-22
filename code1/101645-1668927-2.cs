        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Location = SystemInformation.VirtualScreen.Location;
            this.Size = SystemInformation.VirtualScreen.Size;
        }
