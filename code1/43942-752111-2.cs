    public partial class Form1 : Form
    {
        private bool _isApplicationRun;
        public Form1(bool applicationRun)
        {
            InitializeComponent();
            _isApplicationRun = applicationRun;
        }
        protected override void SetVisibleCore(bool value)
        {
            if (_isApplicationRun)
            {
                _isApplicationRun = false;
                base.SetVisibleCore(false);
                return;
            }
            base.SetVisibleCore(value);
        }
    }
    static class Program
    {
        
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1(true));
        }
    }
