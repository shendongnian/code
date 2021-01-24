    public Generated()
    {
        InitializeComponent();
        textBox1.Text = String.Join(Environment.NewLine, Data.GetAccounts());
    }
