    public Form1()
        {
            InitializeComponent();
            richTextBox1.Click += RichTextBox1_Click;
        }
        private void RichTextBox1_Click(object sender, EventArgs e)
        {
            var start = richTextBox1.SelectionStart;
            var substring = richTextBox1.Text.Substring(0, start);
            var words = substring.Split(new string[] { " " }, StringSplitOptions.None);
            var count = words.Length;
            labelCurrentWordNumber.Text = count.ToString();
        }
