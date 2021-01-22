    public partial class UserControl1 : UserControl {
        public UserControl1() {
            InitializeComponent();
        }
        private void button1_Click(object sender, RoutedEventArgs e) {
            // raise the event (gets bubbled up to the parent of the control)
            this.RaiseEvent(new RoutedEventArgs(MainWindow.ClickedEvent));
        }
    }
