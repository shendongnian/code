            public event EventHandler SelectedIndexChanged;
    
            private void OnSelectedIndexChanged(object sender, EventArgs e)
            {
                if (SelectedIndexChanged != null)
                    SelectedIndexChanged(sender, e);
            }
    
            public UserControl1()
            {
                InitializeComponent();
    
                cb.SelectedIndexChanged += new EventHandler(OnSelectedIndexChanged);
            }
