     public FontFamily[] Families { get; }
     private void Form1_Load(object sender, EventArgs e)
        {
            foreach (FontFamily oneFontFamily in FontFamily.Families)
            {
                comboBox1.Items.Add(oneFontFamily.Name);
            }
            comboBox1.Text = this.richTextBox1.Font.Name.ToString();
            comboBox2.Text = this.richTextBox1.Font.Size.ToString();
            richTextBox1.Focus();
        }
    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
             float size = Convert.ToSingle(((ComboBox)sender).Text);
            richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, size);
        }
    
