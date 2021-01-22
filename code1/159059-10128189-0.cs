    public class MyControl : UserControl
    {
      public event EventHandler InnerButtonClick;
      public MyControl()
      {
        InitializeComponent();
        innerButton.Click += new EventHandler(innerButton_Click);
      }
      private void innerButton_Click(object sender, EventArgs e)
      {
        if (InnerButtonClick != null)
        {
          InnerButtonClick(this, e); // or possibly InnerButtonClick(innerButton, e); depending on what you want the sender to be
        }
      }
    }
