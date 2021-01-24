     public Form1()
    {
        InitializeComponent();
    }
    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {    
        if ((char)Keys.Enter == e.KeyChar)
        {    if(textBox1.Text.Contains("+"))
            {
                  String[] data = textbox1.Text.split("+");
                //String[] data = Text.Split('+');
                int sum = int32.TryParse(data[0]) + Int32.TryParse(data[1]);
               //int sum = Int32.Parse(data[0]) + Int32.Parse(data[1]);
            }
            richTextBox1.Text += " = " + textBox1.Text + "\n";
            textBox1.Clear();  
            textBox1.Focus();
        }
    }
