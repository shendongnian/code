    private bool updatingText;
    public MyForm() {
        InitializeComponent();
        inputTextBox.TextChanged += inputTextBox_TextChanged;
    }
    private void inputTextBox_TextChanged(object sender, EventArgs e)
    {
        if (updatingText)
        {
            return;
        }
        updatingText = true;
        try
        {
            var i = inputTextBox.SelectionStart;
            var text = inputTextBox.Text;
            inputTextBox.Rtf = "";
            inputTextBox.Text = text;
            inputTextBox.SelectionStart = i;
        }
        catch (Exception){}
        updatingText = false;
    }
