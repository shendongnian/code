    public sealed partial class MyUserControl1 : UserControl
    {
        public string RealTimeData => RetrievLiveData();
        public MyUserControl1()
        {
            this.InitializeComponent();
        }
        private string RetrievLiveData()
        {
            return DateTime.Now.ToString();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Bindings.Update();
        }
    }
