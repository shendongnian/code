    public partial class UserControl1 : UserControl {
        public event EventHandler SelectedIndexChanged;
        public UserControl1() {
            InitializeComponent();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            EventHandler handler = SelectedIndexChanged;
            if (handler != null) handler(this, e);
        }
        public object SelectedItem {
            get { return listBox1.SelectedItem; }
        }
    }
