        private Dictionary<string, FlowLayoutPanel> tracks = new Dictionary<string, FlowLayoutPanel>();
        public TestFlowLayout()
        {
            InitializeComponent();
            this.AutoScroll = true;
            // for test
            for (int i = 1; i <= 5; i++)
            {
                AddTrack("Track" + i.ToString());
                for (int j = 1; j <= 10; j++)
                {
                    AddButton("Track" + i.ToString(), "Button" + j.ToString());
                }
            }
        }
        public void AddTrack(string name)
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.AutoSize = true;
            panel.Dock = DockStyle.Top;
            this.Controls.Add(panel);
            tracks.Add(name, panel);
        }
        public void AddButton(string name, string caption)
        {
            Button button = new Button();
            button.Text = caption;
            tracks[name].Controls.Add(button);
        }
