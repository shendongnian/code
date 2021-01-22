    public partial class Form1 : Form {
        int _width;
        public Form1() {
            _width = this.Width;
            InitializeComponent();
        }
        protected override void OnResize(EventArgs e) {
            this.Width = _width;
            base.OnResize(e);
        }
    }
