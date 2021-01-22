        public Form1()
        {
            InitializeComponent();
            HookEvents();
        }
        private void HookEvents() {
            foreach (Control ctl in this.Controls) {
                ctl.MouseClick += new MouseEventHandler(Form1_MouseClick);
            }
        }  
        void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            LogEvent(sender, "MouseClick");
        }
        // and then this just logs to a multiline textbox you have somwhere on the form
        private void LogEvent(object sender, string msg) {
            this.textBox1.Text = string.Format("{0} {1} ({2}) \n {3}",
                DateTime.Now.TimeOfDay.ToString(),
                msg,
                sender.GetType().Name,
                textBox1.Text
                );
        }
