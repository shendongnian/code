    class MyUserControl : UserControl
    {
       public event EventHandler TextBoxValidated
       {
          add { textBox1.Validated += value; }
          remove { textBox1.Validated -= value; }
       }
    }
