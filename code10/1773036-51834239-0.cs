    public ExampleForm()
    {
        InitializeComponent();
        KeyPreview = true;
    }
    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);
        if (e.KeyData == Keys.Enter)
        {
            e.Handled = true;
            // Execute calculator function
        }
    }
