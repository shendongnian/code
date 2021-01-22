    public Form1() {
      System.Threading.Thread.CurrentThread.CurrentUICulture =
        System.Globalization.CultureInfo.GetCultureInfo("fr-FR");
      InitializeComponent();
      textBox1.Text = Properties.Resources.String1;
    }
