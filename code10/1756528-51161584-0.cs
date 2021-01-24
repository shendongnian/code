    public delegate void NotifyEvent();
    public partial class Form1 : Window
    {
        public NotifyEvent notifyDelegate;
        Form2 form2 = null;
        public Form1()
        {
            InitializeComponent();
            // This is 'registering' the ButtonClickedOnForm2 method to the delegate.
            // So, when the delegate is invoked (called), this method gets executed.
            notifyDelegate += new NotifyEvent(ButtonClickedOnForm2);
        }
        public void ButtonClickedOnForm2()
        {
            lblDisp.Background = new SolidColorBrush(Colors.LawnGreen);
        }
        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            // Passing the delegate to `Form2`
            form2 = new Form2(notifyDelegate);
            form2.Show();
        }
    }
