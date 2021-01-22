    private Font originalFont
    public MyForm() {
        InitializeComponent();
        // Font may be modified by content pasted in so keep reference
        originalFont = inputTextBox.Font; 
        inputTextBox.TextChanged += inputTextBox_TextChanged;
    }
    private void inputTextBox_TextChanged(object sender, EventArgs e)
    {
        var i = inputTextBox.SelectionStart;
        inputTextBox.Text = inputTextBox.Text;
        inputTextBox.Font = originalFont;
        inputTextBox.SelectionStart = i;
    }
