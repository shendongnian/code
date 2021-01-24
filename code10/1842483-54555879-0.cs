    public partial class MyTextBox : TextBox
    {
       public MyTextBox()
       {
         InitializeComponent();
       }
      protected override void OnTextChanged(object sender, EventArgs e)
      {
         if (this.Text.Length > 11)
         {
           this.ForeColor = Color.Red;
         }
      }
  
      protected override void OnKeyPressed(object sender, KeyPressedEventArgs e)
      {
        // check for a number, set e.Handled to true if it's not a number
        // may need to handle copy-paste and other similar actions
      }
    }
