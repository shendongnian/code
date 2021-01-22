    public partial class WinForm2 : Form
    {
        public WinForm2()
        {
            InitializeComponent();
        }
        Form parentForm
        internal WinForm2(Form parent)
            : this()
        {
            parentForm = parent
        }
    }
