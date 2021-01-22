    public Form1()
        {
            InitializeComponent();
    
            foreach (Control ctrl in Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Enter += delegate(object sender, EventArgs e)
                                  {
                                      _lastEnteredControl = (Control)sender;
                                  };
                }
            }
        }
