    public partial class SplashForm : Form
    {
      public SplashForm()
      {
        InitializeComponent();
      }
      
      // Not shown here, this is wired to the FormClosing event!!!
      private void SplashForm_FormClosing(object sender, FormClosingEventArgs e)
      {      
        e.Cancel = true;
        this.Hide();
      }
    }
