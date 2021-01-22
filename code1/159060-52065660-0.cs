    public class MyControl : UserControl
    {
      public event EventHandler InnerButtonClick;
    
      public MyControl()
      {
        InitializeComponent();
        innerButton.Click += innerButton_Click;
      }
    
      private void innerButton_Click(object sender, EventArgs e)
      {
          InnerButtonClick?.Invoke(this, e);
          //or
          InnerButtonClick?.Invoke(innerButton, e); 
          //depending on what you want the sender to be
      }
    }
