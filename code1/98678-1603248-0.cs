    System.Threading.Timer timer;
        public Form2()
        {
            InitializeComponent();
            
        }
        private void UpdateFormTextCallback()
        {
            this.Text = "Hello World!";
        }
        private Action UpdateFormText;
        private void DoStuff(object value)
        {
            this.Invoke(UpdateFormText);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            timer = new System.Threading.Timer(new TimerCallback(DoStuff), null, 0, 500);
            UpdateFormText = new Action(UpdateFormTextCallback);
        }
