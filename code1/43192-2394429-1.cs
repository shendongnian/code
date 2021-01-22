        public Form1()
        {
            InitializeComponent();
            //Assuming selected1 and selected2 are defined as integer application settings
            radioGroup1.DataBindings.Add("Selected", Properties.Settings.Default, "selected1");
            radioGroup2.DataBindings.Add("Selected", Properties.Settings.Default, "selected2");
        }
