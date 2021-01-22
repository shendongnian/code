    public partial class Form1 : Form
    {
      public Form1()
      {
        InitializeComponent();
    
        // You can also use the Source property here or in the designer
        webView1.Navigate(new Uri("https://www.microsoft.com"));
      }
    }
