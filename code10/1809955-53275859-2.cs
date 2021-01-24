        public void AddTrack(string name)
        {
            GroupBox group = new GroupBox();
            group.Text = name;
            group.Dock = DockStyle.Top;
            group.AutoSize = false;
            this.Controls.Add(group);
            group.BringToFront();
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.SizeChanged += Panel_SizeChanged;
            panel.AutoSize = true;
            panel.Dock = DockStyle.Top;
            group.Controls.Add(panel);
            tracks.Add(name, panel);
        }
        private void Panel_SizeChanged(object sender, EventArgs e)
        {
            FlowLayoutPanel panel = (FlowLayoutPanel)sender;
            panel.Parent.Height = panel.Size.Height+20;
        }
