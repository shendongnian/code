    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
    
        public bool CheckBoxChecked
        {
            get { return cbxForm2.Checked; }
            set { cbxForm2.Checked = value; }
        }
    }
