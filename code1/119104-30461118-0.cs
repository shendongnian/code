    public FormMain()
    {
        InitializeComponent();
        txtRtb.TextChanged += txtRtb_TextChanged;
    }
    void txtRtb_TextChanged(object sender, EventArgs e)
    {
        RichTextBox rtb = (RichTextBox)sender;
        rtb.SelectAll();
        rtb.SelectionFont = rtb.Font;
        rtb.SelectionColor = System.Drawing.SystemColors.WindowText;
        rtb.Select(rtb.TextLength,0);
    }
