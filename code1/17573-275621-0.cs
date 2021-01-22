            string buffer = String.Empty;
            string buffer2 = String.Empty;
            public Form3()
            {
                InitializeComponent();
                this.richTextBox1.KeyDown += new KeyEventHandler(richTextBox1_KeyDown);
                this.richTextBox1.TextChanged += new EventHandler(richTextBox1_TextChanged);
            }
    
            void richTextBox1_TextChanged(object sender, EventArgs e)
            {
                buffer2 = buffer;
                buffer = richTextBox1.Text;
            }
          
            void richTextBox1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Control && e.KeyCode == Keys.Z)
                {
                    this.richTextBox1.Text = buffer2;
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                richTextBox1.Text = "Changed";
            }
