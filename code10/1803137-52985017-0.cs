    public Form1()
    {
       InitializeComponent();
       textBox1.KeyPress += CheckEnterKeyPress;
    }
    
    private void CheckEnterKeyPress(object sender, KeyPressEventArgs e)
    {
       if (e.KeyChar == (char)Keys.Return)
       {
          var textbox = sender as TextBox;
          Message(socket, textbox.Text);
       }
    }
