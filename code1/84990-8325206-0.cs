     public MyView()
            {
                InitializeComponent();
              
                Messenger.Default.Register<string>(this, "DoFocus", doFocus);
            }
            public void doFocus(string msg)
            {
                if (msg == "focus")
                    this.txtcode.Focus();
            }
