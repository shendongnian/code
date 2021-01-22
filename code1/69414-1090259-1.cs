    public partial class Form2 : Form
    {
        public delegate void TestEvent(KeyPressEventArgs e);
        public event TestEvent mEvent;
        public Form2()
        {
            InitializeComponent();
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (mEvent != null)
            {
                mEvent(e);
            }
            base.OnKeyPress(e);
        }
    }
