        public Form1() {
            InitializeComponent();
            notifyIcon1.MouseMove += delegate
            {
                notifyIcon1.Text = DateTime.Now.TimeOfDay.ToString();
            };
            notifyIcon1.Icon = SystemIcons.Hand;
            notifyIcon1.Visible = true;            
        }
