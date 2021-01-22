    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            this.progressBar1.SendToBack();
            this.transparentLabel1.BringToFront();
            this.transparentLabel1.Text = this.progressBar1.Value.ToString();
            this.transparentLabel1.Invalidate();
       }
        public int Value
        {
            get { return this.progressBar1.Value; }
            set
            {
                this.progressBar1.Value = value; 
            }
        }
    }
